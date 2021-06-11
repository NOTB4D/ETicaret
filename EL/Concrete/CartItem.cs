using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.Concrete
{
   public class CartItem:IEntity
    {
        public int id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

    }
}
