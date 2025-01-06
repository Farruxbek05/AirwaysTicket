using Airways.Core.Entity;
using Airways.DataAccess.Persistence;

namespace Airways.DataAccess.Repository.Impl
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
      public  UserRepository(DataBaseContext dataBaseContext) : base(dataBaseContext) { }
    }
}
