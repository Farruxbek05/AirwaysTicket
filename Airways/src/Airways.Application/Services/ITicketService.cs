using Airways.Application.Models;
using Airways.Application.Models.Ticket;

namespace Airways.Application.Services
{
    public interface ITicketService
    {
        Task<CreateTicketResponceModel> CreateAsync(CreateTicketsModel createTodoItemModel,
      CancellationToken cancellationToken = default);

        Task<BaseResponceModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        Task<IEnumerable<TicketResponceModel>>
            GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<UpdateTicketResponceModel> UpdateAsync(Guid id, UpdateTicketModel updateTodoItemModel,
            CancellationToken cancellationToken = default);
    }
}
