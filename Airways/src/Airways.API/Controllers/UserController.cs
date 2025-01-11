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
        private readonly IWebHostEnvironment _webHostEnvironment;
        public UserContorller(IUserService userService, IJwtTokenHandler jwtTokenHandler, IWebHostEnvironment webHostEnvironment)
        {
            _userService = userService;
            _jwtTokenHandler = jwtTokenHandler;
            _webHostEnvironment = webHostEnvironment;
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
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllUser()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var res = await _userService.GetAllAsync();
            return res == null ? NotFound() : Ok(res);
        }

        [HttpPost("create-user")]
        public async Task<IActionResult> AddUser(UserForCreationDTO userForCreationDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {

                if (userForCreationDTO.ProfileImage != null && userForCreationDTO.ProfileImage.Length > 0)
                {
                    string folder = "Image/cover/";
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(userForCreationDTO.ProfileImage.FileName);
                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);


                    if (!Directory.Exists(serverFolder))
                    {
                        Directory.CreateDirectory(serverFolder);
                    }


                    string filePath = Path.Combine(serverFolder, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await userForCreationDTO.ProfileImage.CopyToAsync(stream);
                    }



                }


                var createUser = await _userService.AddUserAsync(userForCreationDTO);


                var accessToken = _jwtTokenHandler.GenerateAccesToken(createUser);
                var refreshToken = _jwtTokenHandler.GenerateRefreshToken();

                return Ok(new
                {
                    AccessToken = new JwtSecurityTokenHandler().WriteToken(accessToken),
                    RefreshToken = refreshToken,
                    User = createUser
                });
            }

            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
        [HttpPost("LoginUser")]
        public async Task<IActionResult> LoginUser(UserForLoginDTO userForLoginDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
               
                var user = await _userService.GetUserByEmailAsync(userForLoginDTO.Email);

                if (user == null)
                    return Unauthorized(new { Message = "Foydalanuvchi topilmadi!" });

                
                bool isPasswordValid = await _userService.VerifyPassword(user, userForLoginDTO.Password);

                if (!isPasswordValid)
                    return Unauthorized(new { Message = "Email Yoki Parol Hato !!!" });
               
               
                var accessToken = _jwtTokenHandler.GenerateAccesToken(user);
                var refreshToken = _jwtTokenHandler.GenerateRefreshToken();

                return Ok(new
                {
                    AccessToken = new JwtSecurityTokenHandler().WriteToken(accessToken),
                    RefreshToken = refreshToken,
                    User = user
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