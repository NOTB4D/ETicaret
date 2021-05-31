using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.Concrete
{
    public class PaymentConfirm :IEntity


    {
        public bool Status { get; set; }
        public string Message { get; set; }
    }
}
