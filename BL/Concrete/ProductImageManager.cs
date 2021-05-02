using BL.Abstract;
using BL.BusinessAspects.Autofac;
using BL.Constants;
using BL.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DAL.Abstract;
using EL.Concrete;
using EL.DTOs;
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
        private readonly IProductImageDal _ProductImageDal;
        private readonly IProductService _productService;
        private readonly IProductImageService _productImageService;



        public ProductImageManager(IProductService productService, IProductImageDal productImageDal, IProductImageService  productImageService)
        {
            _ProductImageDal = productImageDal;
            _productService = productService;
            _productImageService = productImageService;
        }

        [SecuredOperation("Admin")]
        [ValidationAspect(typeof(ProductImageValidator))]
        public IResult Add(IFormFile file, ProductImage productImage)
        {
            var result = BusinessRules.Run(CheckProductImagesCount(productImage.ProductId));
            if(result!=null)
            {
                return result;
            }
            var query = this.Get(productImage.ProductId).Data;
            if(query.ImagePath.Contains("default"))
            {
                productImage.ImagePath = FileHelper.Add(file);
                productImage.ProductId = productImage.ProductId;
                productImage.Date = DateTime.Now;
                productImage.Id = query.Id;
                _ProductImageDal.Update(productImage);
                    
            }
            else
            {
                productImage.ImagePath = FileHelper.Add(file);
                productImage.Date = DateTime.Now;
                _ProductImageDal.Add(productImage);

            }
            return new SuccessResult(Messages.ProductImageAdded);
        }
        [SecuredOperation("Admin")]
        public IResult Delete(ProductImage productImage)
        {
            IResult result = BusinessRules.Run(CheckIfImageExists(productImage.Id));
            if (result != null)
            {
                return result;
            }
            string path = GetById(productImage.Id).Data.ImagePath;
            FileHelper.Delete(path);
            _ProductImageDal.Delete(productImage);
            return new SuccessResult();
        }

        public IDataResult<ProductImage> Get(int id)
        {
            var productImage = _ProductImageDal.Get(PI => PI.Id == id);
            if( productImage == null)
            {
                return new ErrorDataResult<ProductImage>(Messages.ProductImageNotFound);
            }
            return new SuccessDataResult<ProductImage>(productImage);
                 
        }
        [CacheAspect]
        public IDataResult<List<ProductImage>> GetAll()
        {
            return new SuccessDataResult<List<ProductImage>>(_ProductImageDal.GetAll());
        }

        public IDataResult<List<ProductImageDto>> GetByProductId(int ProductId)
        {
            var result = _productImageService.GetByProductId(ProductId);
            if(result.Data.Any())
            {
                return new SuccessDataResult<List<ProductImageDto>>(result.Data);
            }
            return new SuccessDataResult<List<ProductImageDto>>(new List<ProductImageDto> { new ProductImageDto { ImagePath = "default.jpg", Date = DateTime.Now } });
        }
        [SecuredOperation("Admin")]
        public IResult Update(IFormFile file, ProductImage productImage)
        {
            IResult result = BusinessRules.Run(CheckIfImageExists(productImage.Id));
            if ( result !=null)
            {
                return result;
            }

            ProductImage oldproductImage = GetById(productImage.Id).Data;
            productImage.ImagePath = FileHelper.Update(file, oldproductImage.ImagePath);
            productImage.Date = DateTime.Now;
            productImage.ProductId = oldproductImage.Id;
            _ProductImageDal.Update(productImage);
            return new SuccessResult();

        }

       

        public IDataResult<ProductImage> GetById(int Id)
        {
            return new SuccessDataResult<ProductImage>(_ProductImageDal.Get(PI => PI.Id == Id));
        }
        
        private IResult CheckProductImagesCount(int ProductId)
        {
            var result = _ProductImageDal.GetAll(PI => PI.ProductId == ProductId).Count < 5;
            if(!result)
            {
                return new ErrorResult(Messages.ProductImageCountExceeded);
            }
            return new SuccessResult();
        }
        private IResult CheckIfImageExists(int id)
        {
            if (_ProductImageDal.IsExist(id))
                return new SuccessResult();
            return new ErrorResult(Messages.ProductImageMustBeExists);
        }

        public IResult DeleteByProductId(int ProductId)
        {
            var result = _ProductImageDal.GetAll(x => x.Id == ProductId);
            if (result.Any())
            {
                foreach (var productImage in result)
                {
                    Delete(productImage);
                }
                return new SuccessResult();
            }
            return new ErrorResult(Messages.ProductHaveNoImage);
        }
    }
}
