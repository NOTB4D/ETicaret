using Core.DataAccsess;
using EL.Concrete;
using EL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
   public interface IOrderDal: IEntityRepository<Order>
    {
        List<OrderDetailDto> GetOrderDetails(Expression<Func<OrderDetailDto, bool>> filter = null);
    }
}
