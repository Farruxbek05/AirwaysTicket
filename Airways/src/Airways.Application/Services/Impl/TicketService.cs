using Airways.Application.Models.Payment;
using Airways.Application.Models;
using Airways.Core.Entity;
using Airways.DataAccess.Repository;
using AutoMapper;
using Airways.Application.Models.Ticket;

namespace Airways.Application.Services.Impl
{
    public class TicketService:ITicketService
    {
        private readonly IMapper _mapper;
        private readonly ITicketRepository _ticketRepository;


        public TicketService(ITicketRepository ticketRepository,
            IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TicketResponceModel>> GetAllByListIdAsync(Guid id,
            CancellationToken cancellationToken = default)
        {
            var todoItems = await _ticketRepository.GetAllAsync(ti => ti.Id == id);

            return _mapper.Map<IEnumerable<TicketResponceModel>>(todoItems);
        }

        public async Task<CreateTicketResponceModel> CreateAsync(CreateTicketsModel createTodoItemModel,
            CancellationToken cancellationToken = default)
        {
            var todoItem = _mapper.Map<Tickets>(createTodoItemModel);


            return new CreateTicketResponceModel
            {
                Id = (await _ticketRepository.AddAsync(todoItem)).Id
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
