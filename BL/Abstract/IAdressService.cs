using Core.Utilities.Results;
using EL.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Abstract
{
    public interface IAdressService
    {
        IDataResult<List<Adress>> GetByCustomerId(string customerId);
        IResult Add(Adress adress);
        IResult Update(Adress adress);
        IResult Delete(Adress adress);
    }
}
