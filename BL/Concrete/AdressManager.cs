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
    public class AdressManager : IAdressService
    {
        IAdressDal _adressDal;
        
        public AdressManager(IAdressDal adressDal)
        {
            _adressDal = adressDal;
            
        }

        
        public IResult Add(Adress adress)
        {
            _adressDal.Add(adress);
            return new SuccessResult(Messages.AddressAdded);
        }

        public IResult Delete(int adressId)
        {
            _adressDal.Delete(GetById(adressId).Data);
            return new SuccessResult(Messages.AddressDeleted);
        }

        public IDataResult<List<Adress>> GetByuserId(int userId)
        {
            return new SuccessDataResult<List<Adress>>(_adressDal.GetAll(u => u.UserId == userId));
        }

        public IDataResult<Adress> GetById(int userId)
        {
            
            return new SuccessDataResult<Adress>(_adressDal.Get(u => u.UserId.Equals(userId)));
        }

        public IResult Update(Adress adress)
        {
            _adressDal.Update(adress);
            return new SuccessResult();
        }
    }
}
