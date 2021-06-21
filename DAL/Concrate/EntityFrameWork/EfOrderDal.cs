using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DAL.Abstract;
using EL.Concrete;
using EL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrate.EntityFrameWork
{
    public class EfOrderDal : EfEntityRepositoryBase<Order, EcommerceContext>, IOrderDal
    {
        public List<OrderDetailDto> GetOrderDetails(Expression<Func<OrderDetailDto, bool>> filter = null)
        {
            using EcommerceContext context = new();
            var result = from Product in context.Products
                         join Basket in context.Baskets on Product.ProductID equals Basket.ProductID
                         join Order in context.Orders on Basket.OrderId equals Order.OrderId
                         join User in context.Users on Order.UserId equals User.Id
                         select new OrderDetailDto()
                         {
                             UserId = User.Id,
                             ProductName = Product.ProductName,
                             Quantity = Basket.Quantity,
                             OrderNumber = Order.OrderNumber,
                             OrderDate = Order.OrderDate,
                             Price = Basket.Price,
                             Status = Order.Status,
                             Massage = Order.Massage
                         };
            return filter == null ? result.ToList() : result.Where(filter).ToList();
        }
    }
}
