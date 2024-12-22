using Airways.Core.Entity;
using Airways.DataAccess.Persistence;

namespace Airways.DataAccess.Repository.Impl
{
    public class PaymentRepository:BaseRepository<Payment>,IPaymentRepository
    {
        public PaymentRepository(DataBaseContext dataBaseContext) : base(dataBaseContext) { }
    }
}
