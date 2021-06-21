using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.Concrete
{
   public class Customer:IEntity
    {
        [Key]
        public int UserId { get; set; }
        public long PhoneNumber { get; set; }
        public DateTime BirthDay { get; set; }
        public string IdentityNumber { get; set; }

    }
}
