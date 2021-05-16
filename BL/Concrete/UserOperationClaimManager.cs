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
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        IUserOperationClaimDal _userOperationClaimDal;

        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal )
        {
            _userOperationClaimDal = userOperationClaimDal;
        }

        public IResult AddUserClaim(User user)
        {
            var userOperatinClaim = new UserOperationClaim
            {
                OperationClaimId = 2,
                UserId = user.Id
            };
            _userOperationClaimDal.Add(userOperatinClaim);
            return new SuccessResult();
        }
    }
}
