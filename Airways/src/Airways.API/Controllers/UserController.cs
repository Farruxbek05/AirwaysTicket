using Airways.Application.Models.User;
using Airways.Application.Models;
using Airways.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Airways.API.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService todoItemService)
        {
            _userService = todoItemService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateUserModel createUserModel)
        {
            return Ok(ApiResult<CreateUserResponceModel>.Success(
                await _userService.CreateAsync(createUserModel)));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateUserModel updateUserModel)
        {
            return Ok(ApiResult<UpdateusrResponceModel>.Success(
                await _userService.UpdateAsync(id, updateUserModel)));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            return Ok(ApiResult<BaseResponceModel>.Success(await _userService.DeleteAsync(id)));
        }
    }
}
