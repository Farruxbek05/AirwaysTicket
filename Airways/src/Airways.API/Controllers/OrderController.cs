using Airways.Application.Models;
using Airways.Application.Models.Order;
using Airways.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Airways.API.Controllers
{
    public class OrderController : ApiController
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateOrderModel createUserModel)
        {
            return Ok(ApiResult<CreateOrderResponceModel>.Success(
                await _orderService.CreateAsync(createUserModel)));
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
