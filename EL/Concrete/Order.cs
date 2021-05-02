using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.Concrete
{
   public class Order :IEntity
    {
        public int OrderId { get; set; }
        public int OrderNumber { get; set; }
        public int Status { get; set; }
        public string Massage { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShipCity { get; set; }

        public ICollection<Basket> baskets { get; set; }
    }
}
