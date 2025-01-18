using Airways.Application.DTO;
using Airways.Core.Entity;
using Airways.DataAccess;
using Airways.DataAccess.Authentication;
using Airways.DataAccess.Repository;

namespace Airways.Application.Services.Impl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _users;
        private readonly IEmailService _emailService;

        private readonly IPasswordHasher _passwordHasher;
        public UserService(IUserRepository userRepository,
            IPasswordHasher passwordHasher, IEmailService emailService)
        {
            _users = userRepository;
            _passwordHasher = passwordHasher;
            _emailService = emailService;
        }

        public async Task<UserDTO> GetByIdAsync(Guid id)
        {
            var user = await _users.GetFirstAsync(u => u.Id == id);


            if (user == null)
                return null;

            return new UserDTO
            {
                Name = user.Name,
                Email = user.Email,
                Address = user.Address,

            };
        }

        public async Task<List<UserDTO>> GetAllAsync()
        {
            var users = await _users.GetAllAsync(u => true);
            return users.Select(user => new UserDTO
            {
                Name = user.Name,
                Email = user.Email,
                Address = user.Address,
                Id = user.Id
            }).ToList();
            
        }

        public async Task<UserForCreationDTO> AddUserAsync(UserForCreationDTO userForCreationDTO)
        {
            if (userForCreationDTO == null)
                throw new ArgumentNullException(nameof(userForCreationDTO));

            string randomSalt = Guid.NewGuid().ToString();

            User user = new User
            {
                Name = userForCreationDTO.Name,
                Email = userForCreationDTO.Email,
                Address = userForCreationDTO.Address,


                Salt = randomSalt,
                Password = _passwordHasher.Encrypt(
                    password: userForCreationDTO.Password,
                    salt: randomSalt),
                Pasword2 = userForCreationDTO.Password,


                Role = userForCreationDTO.role.ToString()
            };
            var res = await _users.AddAsync(user);
            var result = new UserDTO
            {
                Address = userForCreationDTO.Address,
                Email = userForCreationDTO.Email,
                Name = userForCreationDTO.Name,
            };
           await _emailService.SendEmailAsync(user);

            return userForCreationDTO;
        }

        public async Task<User> UpdateUserAsync(Guid id, UserDTO userDto)
        {

            if (userDto == null)
                throw new ArgumentNullException(nameof(userDto), "UserDTO cannot be null.");


            var user = await _users.GetFirstAsync(u => u.Id == id);

            if (user == null)
                return null;

            user.Name = userDto.Name;
            user.Email = userDto.Email;
            user.Address = userDto.Address;
            await _users.UpdateAsync(user);
            return user;
        }


        public async Task<bool> DeleteUserAsync(Guid id)
        {
            var user = await _users.GetFirstAsync(u => u.Id == id);

            if (user == null)
                return false;

            await _users.DeleteAsync(user);
            return true;
        }
        public async Task<User> GetUserByEmailAsync(string email)
        {

            return await _users.GetUserByEmailAsync(email);
        }

        public async Task<bool> VerifyPassword(User user, string password)
        {

            return await Task.Run(() => user.Pasword2 == password);
        }


    }
}
