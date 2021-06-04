using BL.Abstract;
using EL.Concrete;
using Iyzipay.Model;
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
    public class PayController : ControllerBase
    {
        IPayService _payService;
        public PayController(IPayService payService)
        {
            _payService = payService;
        }


        [HttpPost("Pay")]
        public IActionResult Pay(IyzicoModel  ıyzicoModel)
        {
            var result = _payService.PayWithIyzico(ıyzicoModel);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}
