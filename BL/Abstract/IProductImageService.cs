using Core.Utilities.Results;
using EL.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Abstract
{
   public interface IProductImageService
    {
        IResult Add(IFormFile file, ProductImage productImage);
        IResult Delete(int Id);
        IResult Update(IFormFile file, ProductImage productImage);
        IDataResult<ProductImage> Get(int Id);
        IDataResult<List<ProductImage>> GetAAll();
        IDataResult<List<ProductImage>> GetImageByProductId(int Id);
    }
}
