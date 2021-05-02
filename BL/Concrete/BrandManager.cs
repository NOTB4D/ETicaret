using BL.Abstract;
using BL.BusinessAspects.Autofac;
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
    
    public class BrandManager : IBrandService
    {
        IBrandDal _branDal;
        public BrandManager(IBrandDal brandDal)
        {
            _branDal = brandDal;
        }
        [SecuredOperation("Admin")]
        public IResult Add(Brand brand)
        {
            _branDal.Add(brand);
            return new SuccessResult();
        }
        [SecuredOperation("Admin")]
        public IResult Delete(Brand brand)
        {
            _branDal.Delete(brand);
            return new SuccessResult();
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_branDal.GetAll());
        }

        public IDataResult<Brand> GetById(int Id)
        {
            return new SuccessDataResult<Brand>(_branDal.Get(b => b.BrandId == Id), Messages.BrandListed);
        }
        [SecuredOperation("Admin")]
        public IResult Update(Brand brand)
        {
            _branDal.Update(brand);
            return new SuccessResult();
        }
    }
}
