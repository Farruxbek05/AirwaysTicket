using Airways.Application.Models;
using Airways.Application.Models.Aicraft;
using Airways.Application.Models.Ticket;

namespace Airways.Application.Services
{
    public interface ITicketService
    {
        Task<CreateTicketResponceModel> CreateAsync(CreateTicketsModel createTodoItemModel,
      CancellationToken cancellationToken = default);

        Task<BaseResponceModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        Task<List<TicketResponceModel>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<UpdateTicketResponceModel> UpdateAsync(Guid id, UpdateTicketModel updateTodoItemModel,
            CancellationToken cancellationToken = default);
    }
}
