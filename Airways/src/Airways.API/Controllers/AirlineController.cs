using Airways.Application.Models;
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
            return Ok(ApiResult<BaseResponceModel>.Success(await _airlineService.DeleteAsync(id)));
        }
    }
}
