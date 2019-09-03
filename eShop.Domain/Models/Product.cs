using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }

        public ICollection<Stock> Stock { get; set; }
        

    }
}
