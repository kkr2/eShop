

using eShop.Database;
using eShop.Domain.Models;
using System.Threading.Tasks;

namespace eShop.App.ProductsAdmin
{
    public class CreateProduct
    {
       private ApplicationDbContext _context;
       public CreateProduct(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response> Do(Request request)
        {
            var product = new Product
            {
                name = request.name,
                Description = request.Description,
                Value = request.Value
            };

            _context.products.Add(product);
            await _context.SaveChangesAsync();

            return new Response
            {
                Id = product.Id,
                name=product.name,
                Description=product.Description,
                Value = product.Value
               
            };
        }
        public class Request
        {
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
