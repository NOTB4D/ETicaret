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
        IResult Delete(SubCategory subCategory);
        IResult Update(SubCategory subCategory);
        IResult Add(SubCategory subCategory);
        IDataResult<List<SubCategory>> GetAll();
        IDataResult<SubCategory> GetByCategoryId(int categoryId);
    }
}
