using eShop.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.App.StockAdmin.GetStocks
{
    public class GetStocks
    {
        ApplicationDbContext _ctx;
        public GetStocks(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }


        public IEnumerable<StockViewModel> Do(int productId) {
            var stock = _ctx.stocks
                .Where(a => a.Id == productId)
                .Select(a=> new StockViewModel
                {
                    Id=a.Id,
                    Description=a.Description,
                    Qty=a.Qty
                })
                .ToList();


            return stock;
        }
    }


    public class StockViewModel
    {
        public int Id { get; set; }
   
        public string Description { get; set; }
        public int Qty { get; set; }
    }
}
