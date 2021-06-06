using BL.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
       
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public User GetByMail(string email)
        {
            return  _userDal.Get(u => u.Email == email);
        }

        public IDataResult<User> GetUserByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email.Equals(email)));
        }

        public IDataResult<OperationClaim> GetClaim(User user)
        {
            return new SuccessDataResult<OperationClaim>(_userDal.GetClaim(user));
        }
    }
}
