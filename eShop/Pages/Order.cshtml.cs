using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShop.App.Orders;
using eShop.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace eShop.UI.Pages
{
    public class OrderModel : PageModel
    {

        private ApplicationDbContext _ctx;
        public OrderModel(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public GetOrder.Response Order { get; set; }

        public void OnGet(string reference)
        {

            Order = new GetOrder(_ctx).Do(reference);

        }
    }
}