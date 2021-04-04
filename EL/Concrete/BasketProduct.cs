using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.Concrete
{
   public class BasketProduct:IEntity
    {
        public int id { get; set; }

        public int Toplam { get; set; }
    }
}
