using Airways.Application.DTO;
using Airways.Application.Services;
using Airways.DataAccess;
using Airways.DataAccess.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace Airways.API.Controllers
{
    public class UserContorller : Controller
    {
        private readonly IUserService _userService;
        private readonly IJwtTokenHandler _jwtTokenHandler;

        public UserContorller(IUserService userService, IJwtTokenHandler jwtTokenHandler)
        {
            _userService = userService;
            _jwtTokenHandler = jwtTokenHandler;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("GetID/{id}")]
        public async Task<IActionResult> GetUser([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var res = await _userService.GetByIdAsync(id);
            return res == null ? NotFound() : Ok(res);
        }

        [HttpPost("create-user")]
        public async Task<IActionResult> AddUser(UserForCreationDTO userForCreationDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var CreateUser = await _userService.AddUserAsync(userForCreationDTO);
                var accesTokent = _jwtTokenHandler.GenerateAccesToken(CreateUser);
                var refreshToken = _jwtTokenHandler.GenerateRefreshToken();

                return Ok(new
                {
                    AccessToken = new JwtSecurityTokenHandler().WriteToken(accesTokent),
                    RefreshToken = refreshToken,
                    User = CreateUser
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPut("update-user/{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid id, [FromBody] UserDTO userDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var res = await _userService.UpdateUserAsync(id, userDTO);
            return res == null ? NotFound() : Ok(res);
        }
        [HttpPut("Delete/{ID}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid ID)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var res = await _userService.DeleteUserAsync(ID);
            return res == null ? NotFound() : Ok(res);
        }

    }
}
