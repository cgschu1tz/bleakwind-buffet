using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BleakwindBuffet.Data;

namespace BleakwindBuffet.Website.Views.Home
{
    public class IndexModel : PageModel
    {
        public IEnumerable<IOrderItem> Entrees => Menu.Entrees();
        public IEnumerable<IOrderItem> Sides => Menu.Sides();
        public IEnumerable<IOrderItem> Drinks => Menu.Drinks();
    }
}
