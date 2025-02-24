﻿using Airways.Application.Models;
using Airways.Application.Models.Airline;
using Airways.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Airways.API.Controllers
{
    public class AirlineController : ApiController
    {
        private readonly IAirlineService _airlineService;

        public AirlineController(IAirlineService airlineService)
        {
            _airlineService = airlineService;
        }
        [HttpGet]
    public async Task<ActionResult<ApiResult<List<AirlineResponceModel>>>> GetAll()
        {
            var result = await _airlineService.GetAllAsync();
            var response = ApiResult<List<AirlineResponceModel>>.Success(result);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateAirlineModel createUserModel)
        {
            return Ok(ApiResult<CreateAirlineResponceModel>.Success(
                await _airlineService.CreateAsync(createUserModel)));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateAirlineModel updateUserModel)
        {
            return Ok(ApiResult<UpdateAirlineResponceModel>.Success(
                await _airlineService.UpdateAsync(id, updateUserModel)));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            return Ok(ApiResult<bool>.Success(await _airlineService.DeleteAsync(id)));
        }
    }
}
