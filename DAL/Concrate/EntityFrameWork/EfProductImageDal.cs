using Core.DataAccess.EntityFramework;
using DAL.Abstract;
using EL.Concrete;
using EL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrate.EntityFrameWork
{
    public class EfProductImageDal : EfEntityRepositoryBase<ProductImage, EcommerceContext>, IProductImageDal
    {
     

        public bool IsExist(int Id)
        {
            using (EcommerceContext context = new EcommerceContext())
            {
                return context.ProductImages.Any(p => p.Id == Id);
            }
        }


    }
}
