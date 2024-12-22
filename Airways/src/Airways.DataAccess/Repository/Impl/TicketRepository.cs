using Airways.Core.Entity;
using Airways.DataAccess.Persistence;

namespace Airways.DataAccess.Repository.Impl
{
    public class TicketRepository:BaseRepository<Tickets>,ITicketRepository
    {
        public TicketRepository(DataBaseContext context) : base(context) { }
    }
}
