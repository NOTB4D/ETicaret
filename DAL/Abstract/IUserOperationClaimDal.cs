﻿using Core.DataAccsess;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
   public  interface IUserOperationClaimDal : IEntityRepository<UserOperationClaim>
    {
    }
}
