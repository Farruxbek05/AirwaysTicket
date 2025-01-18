using Airways.Core.Entity;

namespace Airways.DataAccess.Repository
{
    public interface ITicketRepository : IBaseRepository<Tickets> 
    {
        public Tickets GetTicketById(Guid ticketId);
       
        Task<Tickets?> GetTicketByIdAsync(Guid? ticketId);
        

    }

}
