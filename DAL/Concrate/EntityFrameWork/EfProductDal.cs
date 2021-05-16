using Core.DataAccess.EntityFramework;
using DAL.Abstract;
using EL;
using EL.Concrete;
using EL.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrate.EntityFrameWork
{
    public class EfProductDal : EfEntityRepositoryBase<Product, EcommerceContext>, IProductDal
    {

        public List<ProductDetailDto> GetProductDetails(Expression<Func<ProductDetailDto, bool>> filter = null)
        {
            using EcommerceContext context = new();
            var result = from Product in context.Products
                         join Brand in context.Brands on Product.BrandId equals Brand.BrandId
                         join SubCategory in context.SubCategories on Product.SubCategoryId equals SubCategory.SubCategoryId
                         join Category in context.Categories on SubCategory.SubCategoryId equals Category.CategoryId
                         select new ProductDetailDto()
                         {
                             BrandName = Brand.BrandName,
                             CategoryName = Category.CategoryName,
                             Description = Product.Description,
                             ProductId = Product.ProductID,
                             ProductImages = (from i in context.ProductImages where i.ProductId == Product.ProductID select i.ImagePath).ToList(),
                             ProductName = Product.ProductName,
                             SubCategoryName = SubCategory.SubCategoryName,
                             UnitInStock = Product.UnitsInStock,
                             UnitPrice = Product.UnitPrice,
                             SubCategoryId=SubCategory.SubCategoryId
                         };
            return filter == null ? result.ToList() : result.Where(filter).ToList();
        }

        public List<ProductSubCategoryDto> GetProductSubCategories()
        {
            using EcommerceContext context = new();
            var result = from p in context.Products
                         join s in context.SubCategories
                         on p.SubCategoryId equals s.SubCategoryId
                         select new ProductSubCategoryDto
                         {
                             ProductId = p.ProductID,
                             ProductName = p.ProductName,
                             SubCategoryId = s.SubCategoryId,
                             SubCategoryName = s.SubCategoryName,
                         };
            return result.ToList();
        }
    }

   
}
