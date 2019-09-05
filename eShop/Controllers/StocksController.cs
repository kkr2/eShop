using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShop.App.StockAdmin;
using eShop.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eShop.UI.Controllers
{
    [Route("[controller]")]
    [Authorize(Policy = "Manager")]
    public class StocksController :Controller
    {
        private ApplicationDbContext _ctx;
        public StocksController(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet("")]
        public IActionResult GetStocks() => Ok(new GetStocks(_ctx).Do());

        [HttpPost("")]
        public async Task<IActionResult> CreateStock([FromBody]CreateStock.Request request) => Ok(await new CreateStock(_ctx).Do(request));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStocks(int id) => Ok((await new DeleteStock(_ctx).Do(id)));

        [HttpPut("")]
        public async Task<IActionResult> UpdateStocks([FromBody]UpdateStock.Request request) => Ok(await new UpdateStock(_ctx).Do(request));

    }
}
