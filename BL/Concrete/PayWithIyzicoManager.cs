using BL.Abstract;
using BL.Constants;
using Core.Utilities.Results;
using DAL.Concrate.EntityFrameWork;
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
        IBasketService _basketService;
        IOrderService _orderService;
        IUserService _userService;
        IProductService _productService;
        

        public PayWithIyzicoManager( IBasketService basketService, IOrderService orderService,IUserService userService,IProductService productService)
        {
            _basketService = basketService;
            _orderService = orderService;
            _userService = userService;
            _productService = productService;
        }


         public  IResult PayWithIyzico(IyzicoModel iyzicomodel)
        {
            var user = _userService.GetByMail(iyzicomodel.Email);
           
            var Order = new Order
            {
                Baskets = iyzicomodel.cartItems.Select(x=> new Basket { 
                    ProductID = x.Product.ProductID,
                    Price = x.Product.UnitPrice,
                    Quantity = x.Quantity
                }).ToList(),
                UserId = user.Id,
                OrderNumber = 11,
                Massage = "Siparişiniz Alındı",
                OrderDate = DateTime.Now,
                ShipCity = iyzicomodel.City,
                Status = 0
            };
            _orderService.Add(Order);
            var Basket = iyzicomodel.cartItems.Select(x => new Basket
            {
                OrderId = Order.OrderId,
                ProductID = x.Product.ProductID,
                Price = x.Product.UnitPrice,
                Quantity = x.Quantity
            }).ToList();

            foreach(var basket in Basket)
            {
                _basketService.Add(basket);
            }
            
            Options options = new Options
            {
                ApiKey = "sandbox-xGBbmai2cuUeE1CkM7Q1FwmOUdtdV3y9",
                SecretKey = "sandbox-yhAYsuhigOIUKss2mNLdw8ChNzPlNSP2",
                BaseUrl = "https://sandbox-api.iyzipay.com"
            };

            CreatePaymentRequest request = new CreatePaymentRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = Order.OrderId.ToString(),
                Price = iyzicomodel.Price,
                PaidPrice = iyzicomodel.Price,
                Currency = Currency.TRY.ToString(),
                Installment = 1,
                BasketId = Order.OrderId.ToString(),
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
                Id = user.Id.ToString(),
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

            foreach (var item in iyzicomodel.cartItems)
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

            request.BasketItems = basketItems;

            Payment payment = Payment.Create(request, options);

            if (payment.Status == "success")
            {
                foreach (var item in Order.Baskets)
                {
                    item.OrderId = Order.OrderId;
                }
                Order.Status = 1;
                Order.Massage = "Sipariş Alındı";
                _orderService.Update(Order);
                return new SuccessResult(Messages.PaySuccess);
            }
            else
            {
                foreach (var item in Order.Baskets)
                {
                    item.OrderId = Order.OrderId;
                }
                Order.Status = 0;
                Order.Massage = payment.ErrorMessage;
                _orderService.Update(Order);
                return new ErrorResult(Messages.payError);
            }
            
        }
    }
}
