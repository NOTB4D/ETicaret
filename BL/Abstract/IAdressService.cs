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
        IDataResult<List<Adress>> GetByuserId(int userId);
        IResult Add(Adress adress);
        IResult Update(Adress adress);
        IResult Delete(int adressId);
        IDataResult<Adress> GetById(int userId);
    }
}
