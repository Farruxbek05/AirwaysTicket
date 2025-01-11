using Airways.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Airways.DataAccess.Repository
{
    public interface IUserRepository: IBaseRepository<User>
    {
        Task<User?> GetUserByEmailAsync(string email);
    }
}
