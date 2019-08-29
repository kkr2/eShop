using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShop.App.Cart;
using eShop.Database;
using Microsoft.AspNetCore.Mvc;

namespace eShop.UI.ViewComponents
{
    public class CardViewComponent :ViewComponent
    {
        private ApplicationDbContext _ctx;
        public CardViewComponent(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public IViewComponentResult Invoke(string view = "Default")
        {
            return View(view,new GetCart(HttpContext.Session, _ctx).Do());
        }
    }
}
