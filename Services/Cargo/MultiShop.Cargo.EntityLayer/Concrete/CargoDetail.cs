﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.EntityLayer.Concrete
{
    public class CargoDetail
    {
        public int CargoDetailId { get; set; }
        public int CargoCustomerId { get; set; }
        public CargoCustomer CargoCustomer { get; set; }
        public string  ReceiverCustomer { get; set; }
    }
}
