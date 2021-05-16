using BL.Abstract;
using BL.BusinessAspects.Autofac;
using BL.Constants;
using BL.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DAL.Abstract;
using EL.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Concrete
{
    public class ProductImageManager : IProductImageService
    {

        IProductImageDal _productImageDal;

        public ProductImageManager(IProductImageDal productImageDal)
        {
            _productImageDal = productImageDal;
        }

        //[ValidationAspect(typeof(ProductImageValidator))]
        //[SecuredOperation("admin")]
        public IResult Add(IFormFile file, ProductImage productImage)
        {
            var imageCount = _productImageDal.GetAll(p => p.ProductId == productImage.ProductId).Count;
            if (imageCount>=5)
            {
                return new ErrorResult(Messages.ProductImageCountExceeded);
            }
            var imageResult = FileHelper.Upload(file);
            if(!imageResult.Success)
            {
                return new ErrorResult(imageResult.Messages);
            }
            productImage.ImagePath = imageResult.Messages;
            _productImageDal.Add(productImage);
            return new SuccessResult(Messages.ProductImageAdded);
        }
        //[ValidationAspect(typeof(ProductImageValidator))]
        //[SecuredOperation("admin")]
        public IResult Delete(int Id)
        {
            var image = _productImageDal.Get(p => p.Id == Id);
            if (image==null)
            {
                return new ErrorResult(Messages.ProductHaveNoImage);
            }
            FileHelper.Delete(image.ImagePath);
            _productImageDal.Delete(Get(Id).Data);
            return new SuccessResult(Messages.productDeleted);
        }

        public IDataResult<ProductImage> Get(int Id)
        {
            return new SuccessDataResult<ProductImage>(_productImageDal.Get(p => p.Id == Id));
        }

        public IDataResult<List<ProductImage>> GetAAll()
        {
            return new SuccessDataResult<List<ProductImage>>(_productImageDal.GetAll());
        }

        public IDataResult<List<ProductImage>> GetImageByProductId(int Id)
        {
            IResult result = BusinessRules.Run(CheckIfProductImageNull(Id));
            if(result != null)
            {
                return new ErrorDataResult<List<ProductImage>>(result.Messages);
            }
            return new SuccessDataResult<List<ProductImage>>(CheckIfProductImageNull(Id).Data);
        }

        //[SecuredOperation("admin")]
            public IResult Update(IFormFile file, ProductImage productImage)
        {
            var IsImage = _productImageDal.Get(p => p.Id == productImage.Id);
            if(IsImage == null)
            {
                return new ErrorResult(Messages.ProductHaveNoImage);
            }
            var updatedFile = FileHelper.Update(file, IsImage.ImagePath);
            if (!updatedFile.Success)
            {
                return new ErrorResult(updatedFile.Messages);
            }
            productImage.ImagePath = updatedFile.Messages;
            return new SuccessResult(Messages.productImageUpdated);
        }

        private IDataResult<List<ProductImage>> CheckIfProductImageNull(int id)
        {
            try
            {
                string path = @"\images\logo.jpg";
                var result = _productImageDal.GetAll(c => c.ProductId == id).Any();
                if (!result)
                {
                    List<ProductImage> productImage = new List<ProductImage>();
                    productImage.Add(new ProductImage { ProductId = id, ImagePath = path, Date = DateTime.Now });
                    return new SuccessDataResult<List<ProductImage>>(productImage);
                }
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<List<ProductImage>>(exception.Message);
            }

            return new SuccessDataResult<List<ProductImage>>(_productImageDal.GetAll(p => p.ProductId == id).ToList());
        }

    }
}
