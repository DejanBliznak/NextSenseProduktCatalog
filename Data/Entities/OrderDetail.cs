﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class OrderDetail
    {
        public int ProductID { get; set; }
        public int OrderID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }


        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
