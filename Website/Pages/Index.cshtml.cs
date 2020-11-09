using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BleakwindBuffet.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BleakwindBuffet.Website.Pages
{
    public class IndexModel : PageModel
    {
        public IEnumerable<IOrderItem> Entrees
        {
            get {
                var items = Menu.Search(Menu.Entrees(), SearchTerms);
                items = Menu.FilterByCalories(items, CaloriesMin, CaloriesMax);
                items = Menu.FilterByCategory(items, Categories);
                items = Menu.FilterByPrice(items, PriceMin, PriceMax);
                return items;
            }
        }

        public IEnumerable<IOrderItem> Sides
        {
            get {
                var items = Menu.Search(Menu.Sides(), SearchTerms);
                items = Menu.FilterByCalories(items, CaloriesMin, CaloriesMax);
                items = Menu.FilterByCategory(items, Categories);
                items = Menu.FilterByPrice(items, PriceMin, PriceMax);
                return items;
            }
        }

        public IEnumerable<IOrderItem> Drinks
        {
            get {
                var items = Menu.Search(Menu.Drinks(), SearchTerms);
                items = Menu.FilterByCalories(items, CaloriesMin, CaloriesMax);
                items = Menu.FilterByCategory(items, Categories);
                items = Menu.FilterByPrice(items, PriceMin, PriceMax);
                return items;
            }
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
