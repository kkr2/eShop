using eShop.App.ProductsAdmin;
using eShop.App.StockAdmin;
using eShop.Database;
using Microsoft.AspNetCore.Mvc;

using System.Linq;
using System.Threading.Tasks;
using eShop.App.UsersAdmin;
using Microsoft.AspNetCore.Authorization;

namespace eShop.UI.Controllers
{
    [Route("[controller]")]
    [Authorize(Policy = "Admin")]
    public class UsersController : Controller
    {
        private CreateUser _createUser;

        public UsersController(CreateUser createUser)
        {
            _createUser = createUser;
        }

        public async Task<IActionResult> CreateUser([FromBody]CreateUser.Request request)
        {
            await _createUser.Do(request);
            return Ok();
        }




    }
}
