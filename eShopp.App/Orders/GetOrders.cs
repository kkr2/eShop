using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShop.Database;


namespace eShop.App.Orders
{
    public class GetOrders
    {
        private ApplicationDbContext _ctx;

        public GetOrders(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public class Response
        {
            public int Id { get; set; }
            public string OrderRef { get; set; }
            public string Email { get; set; }

        }

        public IEnumerable<Response> Do(int status) =>
            _ctx.orders
                .Where(x => x.Status ==  status)
                .Select(x => new Response
                {
                    Id = x.Id,
                    OrderRef = x.OrderRef,
                    Email = x.Email
                })
                .ToList();

    }
}
