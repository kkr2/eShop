using eShop.Database;
using eShop.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.App.Cart
{
    public class GetCart
    {
        private ISession _session;
        private ApplicationDbContext _ctx;
        public GetCart(ISession session, ApplicationDbContext ctx)
        {
            _session = session;
            _ctx = ctx;
        }

        public class Response
        {
            public string Name { get; set; }
            public string Value { get; set; }
            public int StockId { get; set; }
            public int Qty { get; set; }
        }

        public IEnumerable<Response> Do()
        {

            var stringObj = _session.GetString("cart");

            if (string.IsNullOrEmpty(stringObj))
            {
                return new List<Response>();
            }

            var cartList = JsonConvert.DeserializeObject<List<CartProduct>>(stringObj);

            var response = _ctx.stocks
                .Include(x => x.Product)
                .Where(x => cartList.Any(y=>y.StockId==x.Id))
                .Select(x => new Response
                {
                    Name = x.Product.name,
                    Value = x.Product.Value.ToString("N2"),
                    StockId=x.Id,
                    Qty = cartList.FirstOrDefault(y=>y.StockId==x.Id).Qty

                })
                .ToList();
            

            return response;
        }
    }
}
