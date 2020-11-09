using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BleakwindBuffet.Website.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }

        [BindProperty(SupportsGet = true)]
        public string SearchTerms { get; set; }

        [BindProperty(SupportsGet = true)]
        public decimal? PriceMin { get; set; }

        [BindProperty(SupportsGet = true)]
        public decimal? PriceMax { get; set; }

        [BindProperty(SupportsGet = true)]
        public uint? CaloriesMin { get; set; }

        [BindProperty(SupportsGet = true)]
        public uint? CaloriesMax { get; set; }

        [BindProperty(SupportsGet = true)]
        public string[] Categories { get; set; }
    }
}
