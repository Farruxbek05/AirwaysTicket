using Airways.Core.Entity;
using Airways.DataAccess.Persistence;

namespace Airways.DataAccess.Repository.Impl
{
    public class PricePolicyRepository:BaseRepository<PricePolicy>,IPricePolyceRepository
    {
        public PricePolicyRepository(DataBaseContext dataBaseContext) : base(dataBaseContext) { }
    }
}
