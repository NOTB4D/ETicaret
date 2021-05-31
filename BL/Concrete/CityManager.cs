using BL.Abstract;
using BL.Constants;
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
    public class CityManager : ICityService
    {
        ICityDal _cityDal;
        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }
        public IResult Add(City city)
        {
            _cityDal.Add(city);
            return new SuccessResult(Messages.CityAdd);
        }

        public IResult Delete(int cityId)
        {
            _cityDal.Delete(GetById(cityId).Data);
            return new SuccessResult();
        }

        public IDataResult<List<City>> GetAll()
        {
            return new SuccessDataResult<List<City>>(_cityDal.GetAll(), "Şehirler Listelendi");
        }

        public IDataResult<City> GetById(int cityId)
        {
            return new SuccessDataResult<City>(_cityDal.Get(c => c.id.Equals(cityId)));
        }

        public IResult Update(int cityId)
        {
            _cityDal.Update(GetById(cityId).Data);
            return new SuccessResult();
        }
    }
}
