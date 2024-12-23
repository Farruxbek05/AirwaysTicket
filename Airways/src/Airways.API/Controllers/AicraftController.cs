using Airways.Application.Models;
using Airways.Application.Models.Aicraft;
using Airways.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Airways.API.Controllers
{
    public class AicraftController : ApiController
    {
        private readonly IAircraftService _aicraftService;

        public AicraftController(IAircraftService aicraftService)
        {
            _aicraftService = aicraftService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateAircraftModel createUserModel)
        {
            return Ok(ApiResult<CreateAicraftResponceModel>.Success(
                await _aicraftService.CreateAsync(createUserModel)));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateAicraftModel updateUserModel)
        {
            return Ok(ApiResult<UpdateAicraftResponceModel>.Success(
                await _aicraftService.UpdateAsync(id, updateUserModel)));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            return Ok(ApiResult<BaseResponceModel>.Success(await _aicraftService.DeleteAsync(id)));
        }
    }
}
