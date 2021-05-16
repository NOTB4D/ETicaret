using BL.Abstract;
using BL.BusinessAspects.Autofac;
using BL.Constants;
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
        //[SecuredOperation("Admin")]
        public IResult Add(SubCategory subCategory)
        {
            _subCategoryDal.Add(subCategory);
            return new SuccessResult(Messages.SubCategoryAdded);

        }

        public IResult Delete(int subCategoryId)
        {
            _subCategoryDal.Delete(GetById(subCategoryId).Data);
            return new SuccessResult();
        }

        public IDataResult<List<SubCategory>> GetAll()
        {
            return new SuccessDataResult<List<SubCategory>>(_subCategoryDal.GetAll(),"listelendi");
        }

        public IDataResult<List<SubCategory>> GetByCategoryId(int categoryId)
        {
            return new SuccessDataResult<List<SubCategory>>(_subCategoryDal.GetAll(s => s.CategoryId == categoryId));
        }

        public IDataResult<SubCategory> GetById(int subCategoryId)
        {
            return new SuccessDataResult<SubCategory>(_subCategoryDal.Get(s => s.SubCategoryId.Equals(subCategoryId)));
        }

        public IResult Update(SubCategory subCategory)
        {
            _subCategoryDal.Update(subCategory);
            return new SuccessResult();
        }
    }
}
