using Airways.Core.Entity;
using Airways.DataAccess.Persistence;

namespace Airways.DataAccess.Repository.Impl
{
    public class OrderRepository:BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(DataBaseContext dataBaseContext):base(dataBaseContext) { }
    }
}
