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
    public class CarouselImageController : ControllerBase
    {
        private ICarouselImageService _carouselImageservice;

        public CarouselImageController(ICarouselImageService carouselImageService)
        {
            _carouselImageservice = carouselImageService;
        }

        [HttpPost("Add")]
        public IActionResult Add ([FromForm(Name = ("Image"))] IFormFile file, [ FromForm] CarouselImage carouselImage)
        {
            var result = _carouselImageservice.Add(file, carouselImage);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("GetAll")]
        public IDataResult<List<CarouselImage>> Get()
        {
            var result = _carouselImageservice.GetAll();
            return result;
        }
    }
}
