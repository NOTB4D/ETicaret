using BL.Abstract;
using Core.Utilities.Results;
using DAL.Abstract;
using EL.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Concrete
{
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;
        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }
        public IDataResult<Order> Add(Order order)
        {
            _orderDal.Add(order);
            return new SuccessDataResult<Order>(order);
        }

        public IResult Update(Order order)
        {
            _orderDal.Update(order);
            return new SuccessResult();
        }
    }
}
