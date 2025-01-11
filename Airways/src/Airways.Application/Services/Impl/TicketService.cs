using Airways.Application.Models;
using Airways.Application.Models.Ticket;
using Airways.Core.Entity;
using Airways.DataAccess.Repository;
using AutoMapper;

namespace Airways.Application.Services.Impl
{
    public class TicketService : ITicketService
    {
        private readonly IMapper _mapper;
        private readonly ITicketRepository _ticketRepository;


        public TicketService(ITicketRepository ticketRepository,
            IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }

        public async Task<List<TicketResponceModel>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var result = await _ticketRepository.GetAllAsync();

            var mapper = _mapper.Map<List<TicketResponceModel>>(result);
            return mapper;
        }

        public async Task<CreateTicketResponceModel> CreateAsync(CreateTicketsModel createTodoItemModel,
            CancellationToken cancellationToken = default)
        {
            var todoItem = _mapper.Map<Tickets>(createTodoItemModel);
            var res = await _ticketRepository.AddAsync(todoItem);
            if (res == null) return null;

            return new CreateTicketResponceModel
            {
                Id = res.Id
            };
        }

        public async Task<UpdateTicketResponceModel> UpdateAsync(Guid id, UpdateTicketModel updateTodoItemModel,
            CancellationToken cancellationToken = default)
        {
            var todoItem = await _ticketRepository.GetFirstAsync(ti => ti.Id == id);

            _mapper.Map(updateTodoItemModel, todoItem);

            return new UpdateTicketResponceModel
            {
                Id = (await _ticketRepository.UpdateAsync(todoItem)).Id
            };
        }

        public async Task<BaseResponceModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var todoItem = await _ticketRepository.GetFirstAsync(ti => ti.Id == id);

            return new BaseResponceModel
            {
                Id = (await _ticketRepository.DeleteAsync(todoItem)).Id
            };
        }
    }
}
