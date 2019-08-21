using eShop.Database;
using eShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.App.StockAdmin.CreateStock
{
    public class CreateStock
    {
        ApplicationDbContext _ctx;
        public CreateStock(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Response> Do (Request request)
        {
            var stock = new Stock {
                Description = request.Description,
                Qty = request.Qty,
                ProductId=request.ProductId
            };
             _ctx.stocks.Add(stock);
            await _ctx.SaveChangesAsync();
            return new Response{
                Id=stock.Id,
                Description=stock.Description,
                Qty=stock.Qty
            };
        }




    }

    public class Request
    {
        public int ProductId { get; set; }
        public string Description { get; set; }
        public int Qty { get; set; }
        
    }

    public class Response
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Qty { get; set; }
    }

}
