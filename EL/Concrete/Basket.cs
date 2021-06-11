﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.Concrete
{
   public class Basket:IEntity
    {
        public int BasketId { get; set; }

        public Product Product { get; set; }
        public int  Quantity { get; set; }
        //public double? Price { get; set;}
        //public int? OrderId { get; set; }
    }
}
