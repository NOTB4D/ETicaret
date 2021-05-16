using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrate.EntityFrameWork
{
    public class EfUserOperationClaimDal : EfEntityRepositoryBase<UserOperationClaim, EcommerceContext>, IUserOperationClaimDal
    {
    }
}
