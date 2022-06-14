using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Pages
{ 
    public class GoldPriceSearch : PageModel
    {
        private readonly ILogger<GoldPriceSearch> _logger;

        [BindProperty]
        public decimal PriceStarts { get; set; }

        public GoldPriceSearch(ILogger<GoldPriceSearch> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
         
        public IActionResult OnPost()
        { 
            return RedirectToPage("./GoldPriceFiltered", new { priceStarts = PriceStarts });
        }
    }
}
