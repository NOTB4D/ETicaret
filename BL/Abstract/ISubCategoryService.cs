using Core.Utilities.Results;
using EL.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Abstract
{
   public interface ISubCategoryService
    {
        IResult Delete(int subCategoryId);
        IResult Update(SubCategory subCategory);
        IResult Add(SubCategory subCategory);
        IDataResult<List<SubCategory>> GetAll();
        IDataResult<List<SubCategory>> GetByCategoryId(int categoryId);
        IDataResult<SubCategory> GetById(int subCategoryId);
    }
}
