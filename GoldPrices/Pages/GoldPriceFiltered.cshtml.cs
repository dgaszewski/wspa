using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Pages
{
    public class GoldPriceFilteredModel : PageModel
    { 
        private IGoldPriceProvider _provider;
        public List<GoldPrice> GoldPrices { get; set; } = new List<GoldPrice>();
        public GoldPriceFilteredModel()
        {
            _provider = new PolishGoldPriceProvider();
        }

        public void OnGet(decimal priceStarts)
        {
            var prices = _provider.GetGoldPrices().Result;

            GoldPrices = prices.Where(x=>x.Price > priceStarts).ToList();
        }
    }
}
