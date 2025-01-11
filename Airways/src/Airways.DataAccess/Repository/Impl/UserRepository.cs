using Airways.Core.Entity;
using Airways.DataAccess.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Airways.DataAccess.Repository.Impl
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly DataBaseContext _dataBaseContext;
      public  UserRepository(DataBaseContext dataBaseContext) : base(dataBaseContext)
        {
            _dataBaseContext=dataBaseContext;
        }
        public async Task<User?> GetUserByEmailAsync(string email) => await _dataBaseContext.AirwaysUser.FirstOrDefaultAsync(u => u.Email == email);
    }
}
