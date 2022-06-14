using GoldPrices.ClassLibrary;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication2.Pages
{
    public class GoldPricesModel : PageModel
    {
        public List<GoldPrice> GoldPrices { get;set; } = new List<GoldPrice>();

        public async Task OnGet()
        {
            IGoldPriceProvider provider = new PolishGoldPriceProvider();
            GoldPrices = await provider.GetGoldPrices();
        }
    }
}
