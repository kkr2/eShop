using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShop.App.Cart;
using eShop.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace eShop.UI.Pages
{
    public class CartModel : PageModel
    {

        private ApplicationDbContext _ctx;
        public CartModel(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<GetCart.Response> Cart { get; set; }
        public IActionResult OnGet()
        {
            Cart = new GetCart(HttpContext.Session, _ctx).Do();

            return Page();
        }
    }
}