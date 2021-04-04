using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.Concrete
{
   public class Product: IEntity
    {
        public int Id { get; set; }
        public string Uadi { get; set; }
        public double Ufiyat { get; set; }
        public string Uresim { get; set; }
        public string Uaciklama { get; set; }
        public int UMarkaId { get; set; }

    }
}
