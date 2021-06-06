using BL.Abstract;
using BL.BusinessAspects.Autofac;
using BL.Constants;
using BL.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DAL.Abstract;
using EL.Concrete;
using EL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryservice;
        //IProductImageService _productImageService;

        
        public ProductManager(IProductDal productDal,ICategoryService categoryService /*IProductImageService productImageService*/)
        {
            _productDal = productDal;
            _categoryservice = categoryService;
            //_productImageService = productImageService;
            
        }
        [SecuredOperation("Admin")]
        [ValidationAspect(typeof(ProductValidator))]
        //[CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)
        {
            // Business codes
            //validation
           IResult result = BusinessRules.Run(CheckIfProductNameExists(product.ProductName), 
                CheckIfProductCountCategoryCorrect(product.ProductID));
            if(result!=null)
            {
                return result;
            }
            
            _productDal.Add(product);
             return new SuccessResult(Messages.ProductAdded);
               
            
        }
        //[CacheAspect]
        public IDataResult<List<Product>> GetAll()
        {
            // iş kodları varsa yaz
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllBySubCategoryId(int Id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.SubCategoryId == Id));
        }
        //[CacheAspect]
        
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product> (_productDal.Get(p => p.ProductID == productId));
           
        }
        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }
        
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult();
        }

        // 10 dan fazla kategory olamaz
        private IResult CheckIfProductCountCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.SubCategoryId == categoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountofCategoryError);
            }
            return new SuccessResult();
        }

        // aynı isimde ürün eklenemez
        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if(result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists); 
            }
            return new SuccessResult();
        }

        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryservice.GetAll();
            if (result.Data.Count>150)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }
    
        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Product product)
        {
            Add(product);
            if (product.UnitPrice < 10)
            {
                throw new Exception("");
            }

            Add(product);

            return null;
        }

        public IResult Delete(int productId)
        {
            _productDal.Delete(GetById(productId).Data);
            //_productImageService.DeleteByProductId(product.ProductID);
            return new SuccessResult();
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetailsByProductId(int Id)
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails(p=>p.ProductId == Id));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetailsBySubcategoryId(int Id)
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails(p=>p.SubCategoryId==Id));
        }

        public IDataResult<List<ProductImageDetailDto>> GetProductImageBySubcategoryId(int Id)
        {
            return new SuccessDataResult<List<ProductImageDetailDto>>(_productDal.GetProductImageDetail(p => p.SubCategoryId == Id));
        }
    }
}
