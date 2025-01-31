using Airways.Application.Models;
using Airways.Application.Models.Aicraft;
using Airways.Application.Models.Ticket;
using Airways.Core.Entity;

namespace Airways.Application.Services
{
    public interface ITicketService
    {
        Task<CreateTicketResponceModel> CreateAsync(CreateTicketsModel createTodoItemModel,
      CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(Guid id);

        Task<List<TicketResponceModel>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<UpdateTicketResponceModel> UpdateAsync(Guid id, UpdateTicketModel updateTodoItemModel,
            CancellationToken cancellationToken = default);
        Task<Tickets> GetTicketByIdAsync(Guid ticketId);
        Task<byte[]> GenerateTicketImageAsync(Guid ticketId);
        Task<byte[]> GenerateTicketImage(string passengerName, string departureCity, string arrivalCity, DateTime scheduledDepartureTime, string seatNumber);
    }
}
