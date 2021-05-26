using BL.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
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

        [HttpGet("getrole")]
        public IActionResult GellClaims([FromQuery] User user)
        {
            var result = _userService.GetClaims(user);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
