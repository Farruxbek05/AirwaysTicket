using Airways.Application.Models;
using Airways.Application.Models.Aicraft;
using Airways.Application.Models.Order;
using Airways.Application.Services;
using Airways.Application.Services.Impl;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Airways.API.Controllers
{
    [Route("api/order")]
    public class OrderController : ApiController
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet]
        public async Task<ActionResult<ApiResult<List<OrderResponceModel>>>> GetAll()
        {
            var result = await _orderService.GetAllAsync();
            var response = ApiResult<List<OrderResponceModel>>.Success(result);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateOrderModel createUserModel)
        {
            var result = await _orderService.CreateAsync(createUserModel);

            if (result == null) return BadRequest(ApiResult<CreateOrderResponceModel>.Failure());

            return Ok(ApiResult<CreateOrderResponceModel>.Success(result));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateOrderModel updateUserModel)
        {
            return Ok(ApiResult<UpdateOrderResponceModel>.Success(
                await _orderService.UpdateAsync(id, updateUserModel)));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            return Ok(ApiResult<BaseResponceModel>.Success(await _orderService.DeleteAsync(id)));
        }

    }
}
