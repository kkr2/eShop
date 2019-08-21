using eShop.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
         _context.products.ToList().Select(a => new ProductViewModel
            {
                name=a.name,
                Description=a.Description,
                Value=a.Value.ToString("N2")

            });
        public class ProductViewModel
        {
            public string name { get; set; }
            public string Description { get; set; }
            public string Value { get; set; }

        }
    }


    
}

