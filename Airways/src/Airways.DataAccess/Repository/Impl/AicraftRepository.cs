using Airways.Core.Entity;
using Airways.DataAccess.Persistence;

namespace Airways.DataAccess.Repository.Impl
{
    public class AicraftRepository:BaseRepository<Aicraft>,IAircraftRepository
    {
        public AicraftRepository(DataBaseContext dataBaseContext) : base(dataBaseContext) { }
    }
}
