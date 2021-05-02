using Core.Utilities.Results;
using EL.Concrete;
using EL.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Abstract
{
   public  interface IProductImageService
    {
        IDataResult<List<ProductImage>> GetAll();
        IDataResult<ProductImage> Get(int id);
        IDataResult<List<ProductImageDto>> GetByProductId(int ProductId);
        IResult Add(IFormFile file, ProductImage productImage);
        IResult Update(IFormFile file, ProductImage productImage);
        IResult Delete(ProductImage productImage);
        IDataResult<ProductImage> GetById(int Id);

    }
}
