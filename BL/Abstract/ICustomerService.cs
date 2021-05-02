using Core.Utilities.Results;
using EL.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Abstract
{
   public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<Customer> GetById(int Id);
        IResult Update(Customer customer);
        IResult Delete(Customer customer);
        IResult Add(Customer customer);
    }
}
