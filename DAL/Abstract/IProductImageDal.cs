﻿using Core.DataAccsess;
using EL.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
   public  interface IProductImageDal : IEntityRepository<ProductImage>
    {
        bool IsExist(int Id);
    }
}
