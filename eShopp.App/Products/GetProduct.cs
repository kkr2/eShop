using eShop.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.App.Products
{
    public class GetProduct
    {
        private ApplicationDbContext _context;
        public GetProduct(ApplicationDbContext context)
        {
            _context = context;
        }

        public ProductViewModel Do(string name) =>
         _context.products
            .Include(x=>x.Stock)
            .Where(x => x.name == name)
            .Select(a => new ProductViewModel
         {
             name = a.name,
             Description = a.Description,
             Value = a.Value.ToString("N2"),
            Stock= a.Stock.Select(y=> new StockViewModel
            {
                Id=y.Id,
                Description=y.Description,
                InStock=y.Qty > 0
            })
         })
            .FirstOrDefault();
        public class ProductViewModel
        {
            public string name { get; set; }
            public string Description { get; set; }
            public string Value { get; set; }
            public IEnumerable<StockViewModel> Stock { get; set; }
        }


        public class StockViewModel
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public bool InStock { get; set; }

        }
    }
}
