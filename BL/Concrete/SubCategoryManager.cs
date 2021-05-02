using BL.Abstract;
using BL.BusinessAspects.Autofac;
using Core.Utilities.Results;
using DAL.Abstract;
using EL.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Concrete
{
    public class SubCategoryManager : ISubCategoryService
    {
        ISubCategoryDal _subCategoryDal;

        public SubCategoryManager(ISubCategoryDal subCategoryDal)
        {
            _subCategoryDal = subCategoryDal;
        }
        [SecuredOperation("Admin")]
        public IResult Add(SubCategory subCategory)
        {
            _subCategoryDal.Add(subCategory);
            return new SuccessResult();

        }

        public IResult Delete(SubCategory subCategory)
        {
            _subCategoryDal.Delete(subCategory);
            return new SuccessResult();
        }

        public IDataResult<List<SubCategory>> GetAll()
        {
            return new SuccessDataResult<List<SubCategory>>(_subCategoryDal.GetAll());
        }

        public IDataResult<SubCategory> GetByCategoryId(int categoryId)
        {
            return new SuccessDataResult<SubCategory>(_subCategoryDal.Get(s => s.CategoryId == categoryId));
        }

        public IResult Update(SubCategory subCategory)
        {
            _subCategoryDal.Update(subCategory);
            return new SuccessResult();
        }
    }
}
