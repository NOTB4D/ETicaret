using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.Concrete
{
    public class Adress:IEntity
    {
        public int AdressId { get; set; }
        public string CostumerId { get; set; }
        public string Adres { get; set; }
        public string AdressName { get; set; }
        public string ZipCode { get; set; }
        public string city { get; set; }
        public string Country { get; set; }


    }
}
