﻿using Core.DataAccess.EntityFramework;
using DAL.Abstract;
using EL.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrate.EntityFrameWork
{
   public class EfOrderDal : EfEntityRepositoryBase<Order, NorthWindContext>,IOrderDal
    {
    }
}
