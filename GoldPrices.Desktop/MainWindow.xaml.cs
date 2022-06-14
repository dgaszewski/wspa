using GoldPrices.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
    }
}
