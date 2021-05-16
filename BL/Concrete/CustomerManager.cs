using BL.Abstract;
using BL.BusinessAspects.Autofac;
using BL.Constants;
using Core.Aspects.Autofac.Caching;
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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _CustomerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _CustomerDal = customerDal;
        }
        
        public IResult Add(Customer customer)
        {
             _CustomerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }
        [SecuredOperation("Admin")]
        public IResult Delete(int customerId)
        {
            _CustomerDal.Delete(GetById(customerId).Data);
            return new SuccessResult(Messages.CustomerDeleted);
        }
        [SecuredOperation("Admin")]
        [CacheAspect]
        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_CustomerDal.GetAll(), Messages.CustomersListed);
        }
        [SecuredOperation("Admin")]
        public IDataResult<Customer> GetById(int Id)
        {
            return new SuccessDataResult<Customer>(_CustomerDal.Get(c => c.CustomerId == Id.ToString()));
        }
        [SecuredOperation("Admin")]
        public IResult Update(Customer customer)
        {
            _CustomerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }

       
    }
}
