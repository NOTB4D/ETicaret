using EL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.Concrete
{
   public class Brand: IEntity
    {
        public int MarkaId { get; set; }
        public string MarkaAdi { get; set; }
    }
}
