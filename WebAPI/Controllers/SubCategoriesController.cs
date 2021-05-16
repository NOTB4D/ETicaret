using BL.Abstract;
using BL.Concrete;
using Core.Utilities.Results;
using DAL.Concrate.EntityFrameWork;
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
    public class SubCategoriesController : ControllerBase
    {
        ISubCategoryService _subCategoryService;

        public SubCategoriesController(ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService;
        }

        [HttpGet("Get")]
        public IDataResult<List<SubCategory>> get() 
        {
            
            var result = _subCategoryService.GetAll();
            return result;

        }

        [HttpGet("GetByCategoryId")]
        public IActionResult GetByCategoryId(int id)
        {
            var result = _subCategoryService.GetByCategoryId(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpPost("Add")]
        public IActionResult Add(SubCategory subCategory)
        {
            var result = _subCategoryService.Add(subCategory);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


    }
}
