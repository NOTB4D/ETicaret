using Core.DataAccsess;
using EL.Concrete;
using EL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
   public interface ICategoryDal:IEntityRepository<Category>
    {
        List<CategoryDetailDto> GetCategoryDetails();
    }
}
