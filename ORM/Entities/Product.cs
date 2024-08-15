﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
    }
}
