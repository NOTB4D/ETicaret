using BL.Abstract;
using BL.Constants;
using Core.Utilities.Results;
using DAL.Abstract;
using EL.Concrete;
using EL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IResult Add(Category category)
        {
            // Business codes
            if (category.CategoryName.Length < 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _categoryDal.Add(category);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Category>> GetAll()
        {
            //İş kodları
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }

        public IDataResult<List<Category>> GetAllByCategoryId(int Id)
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(p => p.CategoryId == Id));
        }

        public IDataResult<Category> GetById(int categoryId)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(c => c.CategoryId == categoryId));
        }

        public IDataResult<List<CategoryDetailDto>> GetCategoryDetails()
        {
            return new SuccessDataResult<List<CategoryDetailDto>>(_categoryDal.GetCategoryDetails());
        }
    }
}
