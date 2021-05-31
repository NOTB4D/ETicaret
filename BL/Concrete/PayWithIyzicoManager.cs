﻿using BL.Abstract;
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
         public  IResult PayWithIyzico(/*CreatePaymentRequest createPaymentRequest, PaymentCard _paymentCard, Buyer _buyer, Address address, Address shippinadress, List<BasketItem> _basketItems*/)
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
                Price = "1",
                PaidPrice = "1.2",
                Currency = Currency.TRY.ToString(),
                Installment = 1,
                BasketId = "B67832",
                PaymentChannel = PaymentChannel.WEB.ToString(),
                PaymentGroup = PaymentGroup.PRODUCT.ToString()
            };

            PaymentCard paymentCard = new PaymentCard
            {
                CardHolderName = "John Doe",
                CardNumber = "5528790000000008",
                ExpireMonth = "12",
                ExpireYear = "2030",
                Cvc = "123",
                RegisterCard = 0
            };
            request.PaymentCard = paymentCard;

            Buyer buyer = new()
            {
                Id = "BY789",
                Name = "John",
                Surname = "Doe",
                Email = "email@email.com",
                IdentityNumber = "74300864791",
                RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1",
                Ip = "85.34.78.112",
                City = "Istanbul",
                Country = "Turkey",
            };
            request.Buyer = buyer;

            Address shippingAddress = new()
            {
                ContactName = "Jane Doe",
                City = "Istanbul",
                Country = "Turkey",
                Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1",
            };
            request.ShippingAddress = shippingAddress;

            Address billingAddress = new()
            {
                ContactName = "Jane Doe",
                City = "Istanbul",
                Country = "Turkey",
                Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1",
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

            return new SuccessResult(Messages.PaySuccess);
        }
    }
}
