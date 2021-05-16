using BL.Abstract;
using BL.Constants;
using Core.Utilities.Business;
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
            IResult result = BusinessRules.Run(ChechIfCategoryNameExist(category.CategoryName));

            // Business codes
            if (category.CategoryName.Length < 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _categoryDal.Add(category);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(int categoryId)
        {
            _categoryDal.Delete(GetById(categoryId).Data);
            return new SuccessResult();
        }

        public IDataResult<List<Category>> GetAll()
        {
            //İş kodları
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }

      

        public IDataResult<Category> GetById(int categoryId)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(c => c.CategoryId == categoryId));
        }

        public IDataResult<List<CategoryDetailDto>> GetCategoryDetails()
        {
            return new SuccessDataResult<List<CategoryDetailDto>>(_categoryDal.GetCategoryDetails());
        }

        public IResult Update(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult();
        }


        // aynı isimde kategory eklenemez
        public IResult ChechIfCategoryNameExist(string categoryName)
        {
            var result = _categoryDal.GetAll(c => c.CategoryName == categoryName).Any();
            if(result)
            {
                return new ErrorResult(Messages.CategoryAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
