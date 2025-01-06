using Airways.Application.Models;
using Airways.Application.Models.Aicraft;
using Airways.Application.Models.PricePolycy;
using Airways.Application.Services;
using Airways.Application.Services.Impl;
using Microsoft.AspNetCore.Mvc;

namespace Airways.API.Controllers
{
    public class PricePolicyController : ApiController
    {
        private readonly IPricePolicyService _pricepolicyService;

        public PricePolicyController(IPricePolicyService pricepolicyService)
        {
            _pricepolicyService = pricepolicyService;
        }
       
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreatePricePolicyModel createUserModel)
        {
            return Ok(ApiResult<CreatePricePolicyResponceModel>.Success(
                await _pricepolicyService.CreateAsync(createUserModel)));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdatePricePolicyModel updateUserModel)
        {
            return Ok(ApiResult<UpdatePricePolicyResponceModel>.Success(
                await _pricepolicyService.UpdateAsync(id, updateUserModel)));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            return Ok(ApiResult<BaseResponceModel>.Success(await _pricepolicyService.DeleteAsync(id)));
        }
    }
}
