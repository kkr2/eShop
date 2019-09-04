using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShop.App.Cart;
using eShop.App.Products;
using eShop.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace eShop.UI.Pages
{
    public class ProductModel : PageModel
    {

        private ApplicationDbContext _cnt;
        public ProductModel(ApplicationDbContext cnt)
        {
            _cnt = cnt;
        }

        [BindProperty]
        public AddToCart.Request CartViewModel { get; set; }
        

        public GetProduct.ProductViewModel Product { get; set; }

        public async Task<IActionResult> OnGet(string name)
        {
            Product = await new GetProduct(_cnt).Do(name.Replace("-"," "));

            if (Product == null)
            {
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }

        public async Task<IActionResult> OnPost()
        {
           var res = await new AddToCart(HttpContext.Session,_cnt).Do(CartViewModel);
           if (res)
               return RedirectToPage("Cart");
           else
               return Page();
        }
    }
}