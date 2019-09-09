using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShop.Database;

namespace eShop.App.Orders
{
    public class UpdateOrder
    {
        private ApplicationDbContext _ctx;  

        public UpdateOrder(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<bool> Do(int id)
        {
            var order = _ctx.orders.FirstOrDefault(x => x.Id == id);
            order.Status = order.Status + 1;
            return await _ctx.SaveChangesAsync() > 0;
        }

    }
}
