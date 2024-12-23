using Airways.Application.Models;
using Airways.Application.Models.Reys;
using Airways.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Airways.API.Controllers
{
    public class ReysContoller : ApiController
    {
        private readonly IReysService _reysService;

        public ReysContoller(IReysService reysService)
        {
            _reysService = reysService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateReysModel createUserModel)
        {
            return Ok(ApiResult<CreateReysResponceModel>.Success(
                await _reysService.CreateAsync(createUserModel)));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateReysModel updateUserModel)
        {
            return Ok(ApiResult<UpdateReysResponceModel>.Success(
                await _reysService.UpdateAsync(id, updateUserModel)));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            return Ok(ApiResult<BaseResponceModel>.Success(await _reysService.DeleteAsync(id)));
        }
    }
}
