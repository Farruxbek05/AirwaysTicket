﻿using Airways.Application.Models;
using Airways.Application.Models.Aicraft;
using Airways.Application.Models.PricePolycy;
using Airways.Application.Services;
using Airways.Application.Services.Impl;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Airways.API.Controllers
{
    [Authorize(Policy ="Admin")]
    [Route("api/pricepolicy")]
    public class PricePolicyController : ApiController
    {
        private readonly IPricePolicyService _pricepolicyService;

        public PricePolicyController(IPricePolicyService pricepolicyService)
        {
            _pricepolicyService = pricepolicyService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResult<List<PricePolicyResponceModel>>>> GetAll()
        {
            var result = await _pricepolicyService.GetAllAsync();
            var response = ApiResult<List<PricePolicyResponceModel>>.Success(result);
            return Ok(response);
        }
        [AllowAnonymous]
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
            return Ok(ApiResult<bool>.Success(await _pricepolicyService.DeleteAsync(id)));
        }
    }
}
