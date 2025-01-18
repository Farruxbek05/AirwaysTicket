using Airways.Core.Entity;
using Airways.DataAccess.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Airways.DataAccess.Repository.Impl
{
    public class PaymentRepository:BaseRepository<Payment>,IPaymentRepository
    {
        private readonly DataBaseContext context;
        public PaymentRepository(DataBaseContext dataBaseContext) : base(dataBaseContext) 
        {
            context = dataBaseContext;
        }
        
    }
}
