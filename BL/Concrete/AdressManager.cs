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
        IProductService __productService;
        public AdressManager(IAdressDal adressDal, IProductService productService)
        {
            _adressDal = adressDal;
            __productService = productService;
        }

        [SecuredOperation("Admin,User")]
        public IResult Add(Adress adress)
        {
            _adressDal.Add(adress);
            return new SuccessResult(Messages.AddressAdded);
        }

        public IResult Delete(Adress adress)
        {
            _adressDal.Delete(adress);
            return new SuccessResult(Messages.AddressDeleted);
        }

        public IDataResult<List<Adress>> GetByCustomerId(string customerId)
        {
            _adressDal.Get(x => x.CostumerId.Equals(customerId));
            return new SuccessDataResult<List<Adress>>();
        }

        public IResult Update(Adress adress)
        {
            _adressDal.Update(adress);
            return new SuccessResult();
        }
    }
}
