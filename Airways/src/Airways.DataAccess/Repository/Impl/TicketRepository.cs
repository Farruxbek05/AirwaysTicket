using Airways.Core.Entity;
using Airways.DataAccess.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Airways.DataAccess.Repository.Impl
{
    public class TicketRepository : BaseRepository<Tickets>, ITicketRepository
    {
        private readonly DataBaseContext dataBaseContext;
        public TicketRepository(DataBaseContext context) : base(context) 
        {
            dataBaseContext = context;
        }
        public Tickets GetTicketById(Guid ticketId)
        {
            return dataBaseContext.Tickets.FirstOrDefault(t => t.Id == ticketId);
        }

        public async Task<Tickets?> GetTicketByIdAsync(Guid? ticketId)
        {
            return await _context.Tickets.FirstOrDefaultAsync(t => t.Id == ticketId);
        }
    }
}
