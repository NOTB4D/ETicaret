using BL.Abstract;
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
    public class OrderCOntroller : ControllerBase
    {
        private IOrderService _orderService;
        public OrderCOntroller(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("Get")]
        public IActionResult Get(int UserId)
        {
            var result = _orderService.GetOrderDetails(UserId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
