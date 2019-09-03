
using eShop.App.Cart;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Hosting;

namespace eShop.UI.Pages.Checkout
{
    public class CustomerInformationModel : PageModel
    {
        private IHostingEnvironment _env;

        public CustomerInformationModel(IHostingEnvironment env )
        {
            _env = env;
        }
        [BindProperty]
        public AddCustomerInformation.Request CustomerInformation { get; set; }

        public IActionResult OnGet()
        {
            var information = new GetCustomerInformation(HttpContext.Session).Do();

            if (information == null)
            {
                if (_env.IsDevelopment())
                {
                    CustomerInformation = new AddCustomerInformation.Request
                    {
                        FirstName = "a",
                        LastName = "a",
                        Email = "a@gmail.com",
                        PhoneNumber = "123323",
                        Address1 = "a",
                        Address2 = "a",
                        City = "a",
                        PostCode = "a"
                    };

                }
                return Page();
            }
            else
            {
                return RedirectToPage("/Checkout/Payment");
            }
                

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            new AddCustomerInformation(HttpContext.Session).Do(CustomerInformation);
            return RedirectToPage("/Checkout/Payment");

        }
    }
}