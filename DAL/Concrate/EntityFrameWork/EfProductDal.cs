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
        public List<ProductDetailDto> GetProductDetails()
        {
            using EcommerceContext context = new();
            var result = from p in context.Products
                         join c in context.Categories
                         on p.SubCategoryId equals c.CategoryId
                         select new ProductDetailDto 
                         { 
                             ProductId = p.ProductID, ProductName = p.ProductName, 
                             CategoryName = c.CategoryName, UnitInStock = p.UnitsInStock 
                         };
            return result.ToList();
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
