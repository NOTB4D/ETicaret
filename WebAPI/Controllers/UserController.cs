using BL.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using EL.DTOs;
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
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        //[HttpGet("getrole")]
        //public IActionResult GellClaims([FromQuery] User user)
        //{
        //    var result = _userService.GetClaims(user);
        //    if(result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}

        [HttpGet("GetByMail")]
        public IActionResult GetByMail(string mail)
        {
            var result = _userService.GetUserByMail(mail);
            if (result.Success)
            {
                return Ok(new
                {
                    result.Data.Id,
                    result.Data.FirstName,
                    result.Data.LastName,
                    result.Data.Email,
                    result.Data.Status
                    
                });
            }
            return BadRequest(result);
        }

        [HttpGet("claims")]
        public IActionResult GetClaims(int Id)
        {
            var result = _userService.GetClaims(new User { Id = Id });
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("claim")]
        public IActionResult GetClaim(int Id)
        {
            var result = _userService.GetClaim(new User { Id = Id });
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("updateprofile")]
        public IActionResult ProfileUpdate(UserForUpdateDto userForUpdateDto)
        {
            var result = _userService.EditProfil(userForUpdateDto.User);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
