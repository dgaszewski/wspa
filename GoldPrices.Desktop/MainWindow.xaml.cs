using GoldPrices.ClassLibrary;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace GoldPrices.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void DownloadGoldPrices(object sender, RoutedEventArgs e)
        {
            LoadingLabel.Visibility = Visibility.Visible;

            IGoldPriceProvider provider = new PolishGoldPriceProvider();
            var list = await provider.GetGoldPrices();

            GoldPriceListBox.ItemsSource = list.Select(x => $"The price at {x.Date} was {x.Price}");
            
            LoadingLabel.Visibility = Visibility.Collapsed; 
        } 
        private async void DownloadGoldPrice(object sender, SelectionChangedEventArgs e)
        {
            LoadingLabel.Visibility = Visibility.Visible;
            var selectedItem = ((ListBox)sender).SelectedItem;
            var date = ((string)selectedItem).Substring("The price at ".Length, "YYYY-MM-DD".Length);


            IGoldPriceProvider provider = new PolishGoldPriceProvider();
            var goldPrice = await provider.GetGoldPriceDetails(date);

            DetailsTextBox.Text = $"Detailed price of the gold on selected date {date} is {goldPrice.Price}";

            LoadingLabel.Visibility = Visibility.Collapsed;
            DetailsTextBox.Visibility = Visibility.Visible;
        }
    }
}
