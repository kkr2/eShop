

using eShop.Database;
using eShop.Domain.Models;
using System.Threading.Tasks;
using System.Linq;

namespace eShop.App.ProductsAdmin
{
    public class DeleteProduct
    {
       private ApplicationDbContext _context;
       public DeleteProduct(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Do(int id)
        {
            var Product = _context.products.FirstOrDefault(x => x.Id == id);
            _context.products.Remove(Product);
            await _context.SaveChangesAsync();

            return true;
        }



    }
   
}
