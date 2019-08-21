using System.Collections.Generic;
using System.Threading.Tasks;

using eShop.App.Products;
using eShop.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace eShop.Pages
{
    public class IndexModel : PageModel

    {
        private ApplicationDbContext _cnt;
        public IndexModel(ApplicationDbContext cnt)
        {
            _cnt = cnt;
        }

        

        public IEnumerable<GetProducts.ProductViewModel> Products { get; set; }
        public void OnGet()
        {
            Products = new GetProducts(_cnt).Do();
        }

       
    }
}
