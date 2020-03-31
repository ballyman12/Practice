using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice.BusinessLogic.Interface;
using Practice.Domain.Model;
using Practice.WebAPI.Helpers;

namespace Practice.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : BaseController
    {
        private IOrderBusinessLogic orderBusinessLogic { get; }
        public OrdersController(IOrderBusinessLogic orderBusinessLogic)
        {
            this.orderBusinessLogic = orderBusinessLogic;
        }

        [HttpGet("Get-all-orders")]
        public async Task<ActionResult<APIResponseWrapper<OrderDTO[]>>> GetAllOrders()
        {
            var orders = await orderBusinessLogic.GetAllOrders();
            if (orders.Count == 0) return NotFound();

            var orderDTO = orders.Select(c => c.ToOrderDTO()).ToArray();

            return APIResponse(orderDTO);
        }
    }
}