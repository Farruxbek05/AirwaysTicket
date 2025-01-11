using Airways.Application.Models.Airline;
using Airways.Application.Models;
using Airways.Core.Entity;
using Airways.DataAccess.Repository;
using AutoMapper;
using Airways.Application.Models.Order;
using Airways.Application.Models.Aicraft;
using Airways.DataAccess.Repository.Impl;
using Airways.Application.Models.Classs;

namespace Airways.Application.Services.Impl
{
    public class OrderService:IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;


        public OrderService(IOrderRepository orderRepository,
            IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<List<OrderResponceModel>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var result = await _orderRepository.GetAllAsync();

            var mapper = _mapper.Map<List<OrderResponceModel>>(result);
            return mapper;
        }

        public async Task<CreateOrderResponceModel> CreateAsync(CreateOrderModel createTodoItemModel,
            CancellationToken cancellationToken = default)
        {
            var todoItem = _mapper.Map<Order>(createTodoItemModel);

            var res = await _orderRepository.AddAsync(todoItem);
            if (res == null) return null;

            return new CreateOrderResponceModel
            {
                Id = res.Id
            };
        }

        public async Task<UpdateOrderResponceModel> UpdateAsync(Guid id, UpdateOrderModel updateTodoItemModel,
            CancellationToken cancellationToken = default)
        {
            var todoItem = await _orderRepository.GetFirstAsync(ti => ti.Id == id);

            _mapper.Map(updateTodoItemModel, todoItem);
            var responce = await _orderRepository.UpdateAsync(todoItem);
            if (responce == null) return null;
            return new UpdateOrderResponceModel
            {
                Id = responce.Id
            };
        }

        public async Task<BaseResponceModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var todoItem = await _orderRepository.GetFirstAsync(ti => ti.Id == id);

            return new BaseResponceModel
            {
                Id = (await _orderRepository.DeleteAsync(todoItem)).Id
            };
        }
    }
}
