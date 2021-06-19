using BL.Abstract;
using Core.Utilities.Results;
using EL.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetBySubcategoryId")]
        public IDataResult<List<Product>> GetBySubcategoryId(int Id)
        {
            var result = _productService.GetAllBySubCategoryId(Id);

            return result;
            
        }

        [HttpGet("getproductDetails")]
        public IActionResult GetProductDetails(int Id)
        {
            var result = _productService.GetProductDetailsByProductId(Id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getproductDetailsBySubcategory")]
        public IActionResult GetProductDetailsBySubcategory(int Id)
        {
            var result = _productService.GetProductDetailsBySubcategoryId(Id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getproductImageBySubcategory")]
        public IActionResult GetProductImageBySubcategory(int Id)
        {
            var result = _productService.GetProductImageBySubcategoryId(Id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("GetProductBySearch")]
        public IActionResult GetProductBySearch (string search)
        {
            var result = _productService.GetProductBySearch(search);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}

