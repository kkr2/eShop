using eShop.Domain.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.App.Cart
{
    public class AddToCart
    {
        private ISession _session;
        public AddToCart(ISession session)
        {
            _session = session;
        }

        public class Request
        {
            public int StockId { get; set; }
            public int Qty { get; set; }
        }

        public void Do(Request request)
        {
            var cartProduct = new CartProduct
            {
                StockId = request.StockId,
                Qty = request.Qty
            };
            var stringObj = JsonConvert.SerializeObject(cartProduct);


            _session.SetString("cart", stringObj);
        }

    }
}
