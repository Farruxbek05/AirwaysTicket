using Airways.Application.Models;
using Airways.Application.Models.Aicraft;
using Airways.Application.Models.Payment;
using Airways.Application.Services;
using Airways.Application.Services.Impl;
using Microsoft.AspNetCore.Mvc;

namespace Airways.API.Controllers
{
    public class PaymentController : ApiController
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        [HttpGet]
        public async Task<ActionResult<ApiResult<List<PaymentResponceModel>>>> GetAll()
        {
            var result = await _paymentService.GetAllAsync();
            var response = ApiResult<List<PaymentResponceModel>>.Success(result);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreatePaymentModel createUserModel)
        {
            return Ok(ApiResult<CreatePaymentResponceModel>.Success(
                await _paymentService.CreateAsync(createUserModel)));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdatePaymentModel updateUserModel)
        {
            return Ok(ApiResult<UpdatePaymentResponceModel>.Success(
                await _paymentService.UpdateAsync(id, updateUserModel)));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            return Ok(ApiResult<BaseResponceModel>.Success(await _paymentService.DeleteAsync(id)));
        }
    }
}
