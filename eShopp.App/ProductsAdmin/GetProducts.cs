using eShop.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eShop.App.ProductsAdmin
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
                Id=a.Id,
                name=a.name,
                
                Value=a.Value
            });
        public class ProductViewModel
        {
            public int Id { get; set; }
            public string name { get; set; }
            
            public decimal Value { get; set; }

        }
    }


    
}

