
using System.Threading.Tasks;
using eShop.App.Orders;
using eShop.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eShop.UI.Controllers
{
    [Route("controller")]
   [Authorize(Policy ="Admin")]
    public class OrdersController: Controller
    {
        private ApplicationDbContext _ctx;

        public OrdersController(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }


        [HttpGet("/orders/{status}")]
        public IActionResult GetOrders(int status) => Ok(new GetOrders(_ctx).Do(status));

        [HttpGet("/order/{id}")]
        public IActionResult GetOrder(int id) => Ok(new GetOrder(_ctx).Do(id));

        [HttpPut("/orders/{id}")]
        public async Task<IActionResult> UpdateOrder(int id) => Ok((await new UpdateOrder(_ctx).Do(id)));

    }
}
