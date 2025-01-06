using Airways.Application.DTO;
using Airways.Core.Entity;
using Airways.DataAccess;

namespace Airways.Application.Services
{
    public interface IUserService
    {
        Task<UserDTO> GetByIdAsync(Guid id);
        Task<List<UserDTO>> GetAllAsync();
        Task<UserForCreationDTO> AddUserAsync(UserForCreationDTO userForCreationDto);
        Task<User> UpdateUserAsync(Guid id, UserDTO userDto);
        Task<bool> DeleteUserAsync(Guid id);
    }
}