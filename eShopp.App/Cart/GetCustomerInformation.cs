using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;

namespace eShop.App.Cart
{
   public  class GetCustomerInformation
    {

        private ISession _session;
        public GetCustomerInformation(ISession session)
        {
            _session = session;
        }

        public class Request
        {
            
            public string FirstName { get; set; }
           
            public string LastName { get; set; }
         
        
            public string Email { get; set; }
           
            public string PhoneNumber { get; set; }

       
            public string Address1 { get; set; }
       
            public string Address2 { get; set; }
        
            public string City { get; set; }
         
            public string PostCode { get; set; }
        }

        public Request Do()
        {
           var stringObj =_session.GetString("customer-info" );

           if (String.IsNullOrEmpty(stringObj))
               return null;

           var response = JsonConvert.DeserializeObject<Request>(stringObj);
           return response;



        }
    }
}
