using eShop.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.App.StockAdmin
{
    public class GetStocks
    {
        ApplicationDbContext _ctx;
        public GetStocks(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }


        public IEnumerable<ProductViewModel> Do() {
            var stock = _ctx.products
                .Include(x=>x.Stock)
                .Select(v=> new ProductViewModel
                {
                    Id=v.Id,
                    Description=v.Description,
                    Stock=v.Stock.Select(y=> new StockViewModel
                    {
                        Id=y.Id,
                        Description=y.Description,
                        Qty=y.Qty
                    })
                })
                .ToList();


            return stock;
        }

        public class StockViewModel
        {
            public int Id { get; set; }

            public string Description { get; set; }
            public int Qty { get; set; }
        }

        public class ProductViewModel
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public IEnumerable<StockViewModel> Stock { get; set; }
        }
    }


    
}
