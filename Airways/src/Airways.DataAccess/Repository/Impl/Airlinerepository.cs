using Airways.Core.Entity;
using Airways.DataAccess.Persistence;

namespace Airways.DataAccess.Repository.Impl
{
    public class Airlinerepository:BaseRepository<Airline>,IAirlineRepository
    {
        public Airlinerepository(DataBaseContext dataBaseContext) : base(dataBaseContext) { }
    }
}
