using Airways.Core.Entity;
using Airways.DataAccess.Persistence;

namespace Airways.DataAccess.Repository.Impl
{
    public class ReysRepository:BaseRepository<Reys>, IReysRepository
    {
        public ReysRepository(DataBaseContext dataBaseContext) : base(dataBaseContext) { }
    }
}
