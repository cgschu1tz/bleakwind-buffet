/*
 * Author: Chris Schultz
 * Class name: Index.cshtml.cs
 * Purpose: Defines the model for the Home page.
 */
using BleakwindBuffet.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace BleakwindBuffet.Website.Pages
{
    /// <summary>
    /// The model for the Home page.
    /// </summary>
    public class IndexModel : PageModel
    {
        /// <summary>
        /// The filtered list of entrees
        /// </summary>
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

        /// <summary>
        /// The filtered list of sides
        /// </summary>
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

        /// <summary>
        /// The filtered list of drinks
        /// </summary>
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

        /// <summary>
        /// The filtering search terms
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public string SearchTerms { get; set; }

        /// <summary>
        /// The minimum filtered price (inclusive)
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public decimal? PriceMin { get; set; }

        /// <summary>
        /// The maximum filtered price (inclusive)
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public decimal? PriceMax { get; set; }

        /// <summary>
        /// The minimum filtered calories (inclusive)
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public uint? CaloriesMin { get; set; }

        /// <summary>
        /// The maximum filtered calories (inclusive)
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public uint? CaloriesMax { get; set; }

        /// <summary>
        /// The filtered menu categories (entrees, drinks, sides)
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public string[] Categories { get; set; }
    }
}
