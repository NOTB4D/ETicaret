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
    public class BasketManager : IBasketService
    {
        IBasketDal _basketDal;
        public BasketManager(IBasketDal basketDal)
        {
            _basketDal = basketDal;
        }
        public IResult Add(Basket basket)
        {
            _basketDal.Add(basket);
            return new SuccessResult();
        }

        public IResult Update(Basket basket)
        {
            _basketDal.Update(basket);
            return new SuccessResult();
        }
    }
}
