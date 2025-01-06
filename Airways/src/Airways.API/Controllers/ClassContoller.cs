using Airways.Application.Models;
using Airways.Application.Models.Classs;
using Airways.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Airways.API.Controllers
{
    public class ClassContoller : ApiController
    {
        private readonly IClassService _classService;

        public ClassContoller(IClassService classService)
        {
            _classService = classService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateCLassModel createUserModel)
        {
            return Ok(ApiResult<CreateClassResponceModel>.Success(
                await _classService.CreateAsync(createUserModel)));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateClassModel updateUserModel)
        {
            return Ok(ApiResult<UpdateClassResponceModel>.Success(
                await _classService.UpdateAsync(id, updateUserModel)));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            return Ok(ApiResult<BaseResponceModel>.Success(await _classService.DeleteAsync(id)));
        }
    }
}
