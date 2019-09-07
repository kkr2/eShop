using eShop.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace eShop.App.Products
{
    public class GetProducts
    {
        private ApplicationDbContext _context;
        public GetProducts(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ProductViewModel> Do() =>
         _context.products
             .Include(x=>x.Stock)
             .Select(a => new ProductViewModel
            {
                name=a.name,
                Description=a.Description,
                Value=a.Value.ToString("N2"),
                LowStock=a.Stock.Sum(y=>y.Qty)

            })
             .ToList();
        public class ProductViewModel
        {
            public string name { get; set; }
            public string Description { get; set; }
            public string Value { get; set; }
            public int LowStock { get; set; }
            

        }
    }


    
}

