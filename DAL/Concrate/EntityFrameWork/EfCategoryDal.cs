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
    public class EfCategoryDal : EfEntityRepositoryBase<Category, EcommerceContext>, ICategoryDal
    {
        public List<CategoryDetailDto> GetCategoryDetails()
        {
            using (EcommerceContext context = new EcommerceContext())

            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.SubCategoryId equals c.CategoryId
                             select new CategoryDetailDto { ProductId = p.ProductID, ProductName = p.ProductName, CategoryName = c.CategoryName, UnitInStock = p.UnitsInStock };
                return result.ToList();
            }
        }
    }
}
