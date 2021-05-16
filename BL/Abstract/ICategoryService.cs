using Core.Utilities.Results;
using EL.Concrete;
using EL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Abstract
{
   public interface ICategoryService
    {
        IDataResult<List<Category>> GetAll();
        IDataResult<List<CategoryDetailDto>> GetCategoryDetails();
        IDataResult<Category> GetById(int categoryId);
        IResult Add(Category category);

        IResult Update(Category category);
        IResult Delete(int categoryId);
    }
}
