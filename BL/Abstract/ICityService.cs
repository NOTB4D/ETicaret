using Core.Utilities.Results;
using EL.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Abstract
{
  public  interface ICityService
    {
        IDataResult<List<City>> GetAll();
        IResult Add(City city);
        IResult Update(int cityId);
        IResult Delete(int cityId);
        IDataResult<City> GetById(int cityId);
    }
}
