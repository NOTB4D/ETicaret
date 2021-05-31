using Core.Utilities.Results;
using Iyzipay.Model;
using Iyzipay.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Abstract
{
   public interface IPayService
    {
        IResult PayWithIyzico(/*CreatePaymentRequest createPaymentRequest, PaymentCard paymentCard, Buyer buyer, Address address, Address shippinadress, List<BasketItem> basketItems*/);
    }
}
