using eShop.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.App.StockAdmin
{
    public class DeleteStock
    {


        ApplicationDbContext _ctx;
        public DeleteStock(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<bool> Do(int Id)
        {

            var stock = _ctx.stocks.FirstOrDefault(a => a.Id == Id);
            _ctx.stocks.Remove(stock);

            await _ctx.SaveChangesAsync();
            return true;
        }




    }

   
}

