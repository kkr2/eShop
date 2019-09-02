using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using eShop.App.Cart;
using eShop.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Stripe;

namespace eShop.UI.Pages.Checkout
{
    public class PaymentModel : PageModel
    {
        public string PublicKey { get; }

        private ApplicationDbContext _ctx;

        public PaymentModel(IConfiguration config, ApplicationDbContext ctx)
        {
            PublicKey = config["Stripe:PublicKey"].ToString();
            _ctx = ctx;
        }

        

        public IActionResult OnGet()
        {
            var information = new GetCustomerInformation(HttpContext.Session).Do();

            if (information == null)
            {
                return RedirectToPage("/Checkout/CustomerInformation");
            }

            return Page();
        }

        public IActionResult OnPost(string stripeEmail, string stripeToken)
        {
            var customers = new CustomerService();
            var charges = new ChargeService();
            var CartOrder = new GetOrder(HttpContext.Session, _ctx).Do();


            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                Source =stripeToken
            });

            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = CartOrder.GetTotalCharge(),
                Description = "Purchase",
                Currency = "usd",
                CustomerId = customer.Id
            });


            return RedirectToPage("/Index");
        }
    }
}