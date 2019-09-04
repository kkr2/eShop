﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Domain.Models
{
    public class StockOnHold
    {
        public int Id { get; set; }
        public string Session { get; set; }  
        public int StockId { get; set; }
        public Stock Stock { get; set; }
        public int Qty { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
