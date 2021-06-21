using BL.Abstract;
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
    public class AdressController : ControllerBase
    {
        private IAdressService _adressservice;
        public AdressController(IAdressService adressService)
        {
            _adressservice = adressService;
        }



        [HttpPost("Add")]
        public IActionResult Add(Adress adress)
        {
            var result = _adressservice.Add(adress);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("Get")]
        public IActionResult Get(int UserId)
        {
            var result = _adressservice.GetById(UserId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("GetAllByUserId")]
        public IActionResult GetAllByUserId(int UserId)
        {
            var result = _adressservice.GetByuserId(UserId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
