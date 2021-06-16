using Core.Utilities.Results;
using EL.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Abstract
{
   public interface IBasketService
    {
        IResult Add(Basket basket);
        IResult Update(Basket basket);
    }
}
