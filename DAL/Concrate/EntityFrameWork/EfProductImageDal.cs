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
        public List<ProductImageDto> GetByProductId(int ProductId)
        {
            using (EcommerceContext context = new EcommerceContext())
            {
                var result = from p in context.Products
                             join b in context.Brands on p.BrandId equals b.BrandId
                             join pi in context.ProductImages on p.ProductID equals pi.ProductId
                             join s in context.SubCategories on p.SubCategoryId equals s.SubCategoryId
                             where p.ProductID == ProductId
                             select new ProductImageDto
                             {
                                 BrandName = b.BrandName,
                                 ProductId = p.ProductID,
                                 ProductImage = pi.ImagePath,
                                 ProductName = p.ProductName,
                                 SubCategoryName = s.SubCategoryName,
                                 Id = p.ProductID,
                                  ImagePath = pi.ImagePath,
                                   Date = pi.Date
                             };
                return result.ToList();
            }
        }

        public bool IsExist(int Id)
        {
            using (EcommerceContext context = new EcommerceContext())
            {
                return context.ProductImages.Any(p => p.Id == Id);
            }
        }


    }
}
