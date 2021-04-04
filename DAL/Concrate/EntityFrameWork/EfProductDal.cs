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
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthWindContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorthWindContext context = new NorthWindContext())

            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.Id equals c.CategoryId
                             select new ProductDetailDto { ProductId = p.Id, ProductName = p.Uadi, CategoryName = c.CategoryName, UnitInStock = p.Ufiyat };
                return result.ToList();
            }
        }
    }
}
