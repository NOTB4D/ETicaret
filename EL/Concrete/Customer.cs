using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.Concrete
{
   public class Customer:IEntity
    {
        public string CustomerId { get; set; }
        public int UserId { get; set; }
        public int AdressId { get; set; }
        public long PhoneNumber { get; set; }
        public DateTime BirthDay { get; set; }
        public string IdentityNumber { get; set; }

    }
}
