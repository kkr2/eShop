using eShop.Database;
using System.Linq;

namespace eShop.App.ProductsAdmin
{
    public class GetProduct
    {
        private ApplicationDbContext _context;
        public GetProduct(ApplicationDbContext context)
        {
            _context = context;
        }

        public ProductViewModel Do(int id) =>
         _context.products.Where(a=>a.Id==id).Select(a => new ProductViewModel
            {
                Id = a.Id,
                name=a.name,
                Description=a.Description,
                Value=a.Value.ToString("N2")

         }).FirstOrDefault();
        public class ProductViewModel
        {
            public int Id { get; set; }
            public string name { get; set; }
            public string Description { get; set; }
            public string Value { get; set; }

        }
    }


    
}

