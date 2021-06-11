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
         public  IResult PayWithIyzico(IyzicoModel iyzicomodel)
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
                Price = iyzicomodel.Price,
                PaidPrice = iyzicomodel.Price,
                Currency = Currency.TRY.ToString(),
                Installment = 1,
                BasketId = "B67832",
                PaymentChannel = PaymentChannel.WEB.ToString(),
                PaymentGroup = PaymentGroup.PRODUCT.ToString()
            };

            PaymentCard paymentCard = new PaymentCard
            {
                CardHolderName = iyzicomodel.CardHolderName,
                CardNumber = iyzicomodel.CardNumber,
                ExpireMonth = iyzicomodel.ExpireMonth,
                ExpireYear = iyzicomodel.ExpireYear,
                Cvc = iyzicomodel.Cvc,
                RegisterCard = iyzicomodel.RegisterCard,
            };
            request.PaymentCard = paymentCard;

            Buyer buyer = new()
            {
                Id = "BY789",
                Name = iyzicomodel.Name,
                Surname = iyzicomodel.Surname,
                Email = iyzicomodel.Email,
                IdentityNumber = iyzicomodel.IdentityNumber,
                RegistrationAddress = iyzicomodel.RegistrationAddress,
                Ip = "85.34.78.112",
                City = iyzicomodel.City,
                Country = iyzicomodel.Country,
            };
            request.Buyer = buyer;

            Address shippingAddress = new()
            {
                ContactName = iyzicomodel.Name,
                City = iyzicomodel.City,
                Country = iyzicomodel.Country,
                Description = iyzicomodel.RegistrationAddress,
            };
            request.ShippingAddress = shippingAddress;

            Address billingAddress = new()
            {

                ContactName = iyzicomodel.Name,
                City = iyzicomodel.City,
                Country = iyzicomodel.Country,
                Description = iyzicomodel.RegistrationAddress,
            };
            request.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new List<BasketItem>();

            foreach (var item in iyzicomodel.CartItems)
            {
                BasketItem basketItem = new BasketItem
                {
                    Id = item.Product.ProductID.ToString(),
                    Category1 = item.Product.SubCategoryId.ToString(),
                    Name = item.Product.ProductName,
                    ItemType = BasketItemType.PHYSICAL.ToString(),
                    Price = (item.Product.UnitPrice * item.Quantity).ToString()
                };
                basketItems.Add(basketItem);
            }

            //BasketItem firstBasketItem = new()
            //{
            //    Id = "BI101",
            //    Name = "Binocular",
            //    Category1 = "Collectibles",
            //    ItemType = BasketItemType.PHYSICAL.ToString(),
            //    Price = "0.3"
            //};
            //basketItems.Add(firstBasketItem);
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
