using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice.BusinessLogic.Command.Interface;
using Practice.BusinessLogic.Command.Result;
using Practice.BusinessLogic.Command.Validation;
using Practice.BusinessLogic.Interface;
using Practice.BusinessLogic.Validation.Result;
using Practice.Domain.Model;
using Practice.WebAPI.Helpers;

namespace Practice.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : BaseController
    {
        private IOrderBusinessLogic orderBusinessLogic { get; }
        private OrderValidation orderValidation { get; }
        public OrdersController(IOrderBusinessLogic orderBusinessLogic, OrderValidation orderValidation)
        {
            this.orderBusinessLogic = orderBusinessLogic;
            this.orderValidation = orderValidation;
        }

        [HttpGet("Get-all-orders")]
        public async Task<ActionResult<APIResponseWrapper<OrderDTO[]>>> GetAllOrders()
        {
            var orders = await orderBusinessLogic.GetAllOrders();

            if (orders.Count == 0) return NotFound();

            var orderDTO = orders.Select(c => c.ToOrderDTO(c)).ToArray();

            return APIResponse(orderDTO);
        }

        [HttpGet("Get-order-by/{orderId}")]
        public async Task<ActionResult<APIResponseWrapper<OrderDTO>>> GetOrderById(int orderId)
        {
            var order = await orderBusinessLogic.GetOrderById(orderId);

            if (order == null) return NotFound();

            var orderDTO = order.ToOrderDTO(order);

            return APIResponse(orderDTO);

        }

        [HttpPost("Create-order")]
        public async Task<ActionResult<APIResponseWrapper<OrderCreateCommand>>> CreateOrder(OrderCreateCommand order)
        {
            var validation = this.orderValidation.Validate(order, ruleSet: "creating");

            ValidationResult validationResult = new ValidationResult(validation);

            if (!validationResult.IsValid)
                return APIResponse<OrderCreateCommand>(validationResult);
            else
            {
                var result = await orderBusinessLogic.CreateOrder(order);
                if (result is CommandResult command && !command.Success)
                    return APIResponse<OrderCreateCommand>(result, StatusCodes.Status400BadRequest);

                return APIResponse(new OrderCreateCommand()
                {
                    OrderId = order.OrderId,
                    OrderName = order.OrderName,
                    SupplierId = order.SupplierId,
                    ItemsId = order.ItemsId

                });
            }

        }

        [HttpPatch("Update-order")]
        public async Task<ActionResult<APIResponseWrapper<ICommandBase>>> UpdateOrder(OrderCreateCommand order)
        {
            var validation = this.orderValidation.Validate(order, ruleSet: "updating");

            ValidationResult validationResult = new ValidationResult(validation);
            if (validationResult.IsValid)
            {
                var result = await orderBusinessLogic.UpdateOrder(order);
                    return APIResponse<ICommandBase>(result, StatusCodes.Status400BadRequest);
            }

            return APIResponse<ICommandBase>(validationResult);
        }
    }
}