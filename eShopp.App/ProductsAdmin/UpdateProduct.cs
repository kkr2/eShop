

using eShop.Database;
using eShop.Domain.Models;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.App.ProductsAdmin
{
    public class UpdateProduct
    {
       private ApplicationDbContext _context;
       public UpdateProduct(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response> Do(Request request)
        {
            var product = _context.products.FirstOrDefault(a => a.Id == request.Id);
            product.name = request.name;
            product.Description = request.Description;
            product.Value = request.Value;
            await _context.SaveChangesAsync();

            return new Response {
                Id=product.Id,
                name=product.name,
                Description=product.Description,
                Value=product.Value
            };
        }
        public class Request
        {
            public int Id { get; set; }
            public string name { get; set; }
            public string Description { get; set; }
            public decimal Value { get; set; }

        }

        public class Response
        {
            public int Id { get; set; }
            public string name { get; set; }
            public string Description { get; set; }
            public decimal Value { get; set; }

        }
    }
   
}
