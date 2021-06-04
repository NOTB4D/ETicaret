using BL.Abstract;
using BL.Constants;
using Core.Utilities.Results;
using EL.Concrete;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Concrete
{
    public class PayWithIyzicoManager : IPayService

    {
         public  IResult PayWithIyzico(IyzicoModel ıyzicoModel)
        {
            Options options = new Options
            {
                ApiKey = "sandbox-xGBbmai2cuUeE1CkM7Q1FwmOUdtdV3y9",
                SecretKey = "sandbox-yhAYsuhigOIUKss2mNLdw8ChNzPlNSP2",
                BaseUrl = "https://sandbox-api.iyzipay.com"
            };

            CreatePaymentRequest request = new CreatePaymentRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = "123456789",
                Price = "0.3",
                PaidPrice = "0.3",
                Currency = Currency.TRY.ToString(),
                Installment = 1,
                BasketId = "B67832",
                PaymentChannel = PaymentChannel.WEB.ToString(),
                PaymentGroup = PaymentGroup.PRODUCT.ToString()
            };

            PaymentCard paymentCard = new PaymentCard
            {
                CardHolderName = ıyzicoModel.CardHolderName,
                CardNumber = ıyzicoModel.CardNumber,
                ExpireMonth = ıyzicoModel.ExpireMonth,
                ExpireYear = ıyzicoModel.ExpireYear,
                Cvc = ıyzicoModel.Cvc,
                RegisterCard = ıyzicoModel.RegisterCard,
            };
            request.PaymentCard = paymentCard;

            Buyer buyer = new()
            {
                Id = "BY789",
                Name = ıyzicoModel.Name,
                Surname = ıyzicoModel.Surname,
                Email = ıyzicoModel.Email,
                IdentityNumber = ıyzicoModel.IdentityNumber,
                RegistrationAddress = ıyzicoModel.RegistrationAddress,
                Ip = "85.34.78.112",
                City = ıyzicoModel.City,
                Country = ıyzicoModel.Country,
            };
            request.Buyer = buyer;

            Address shippingAddress = new()
            {
                ContactName = ıyzicoModel.Name,
                City = ıyzicoModel.City,
                Country = ıyzicoModel.Country,
                Description = ıyzicoModel.RegistrationAddress,
            };
            request.ShippingAddress = shippingAddress;

            Address billingAddress = new()
            {

                ContactName = ıyzicoModel.Name,
                City = ıyzicoModel.City,
                Country = ıyzicoModel.Country,
                Description = ıyzicoModel.RegistrationAddress,
            };
            request.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new();
            BasketItem firstBasketItem = new()
            {
                Id = "BI101",
                Name = "Binocular",
                Category1 = "Collectibles",
                ItemType = BasketItemType.PHYSICAL.ToString(),
                Price = "0.3"
            };
            basketItems.Add(firstBasketItem);
            request.BasketItems = basketItems;

            Payment payment = Payment.Create(request, options);

            if (payment.Status == "success")
            {

                return new SuccessResult(Messages.PaySuccess);
            }
            return new ErrorResult(Messages.payError);
        }
    }
}
