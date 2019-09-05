using eShop.App.ProductsAdmin;
using eShop.App.StockAdmin;
using eShop.Database;
using Microsoft.AspNetCore.Mvc;

using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace eShop.UI.Controllers
{
    [Route("[controller]")]
    [Authorize(Policy = "Admin")]
    public class AdminController : Controller
    {
        private ApplicationDbContext _ctx;

        public AdminController(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        

        

    }
}
