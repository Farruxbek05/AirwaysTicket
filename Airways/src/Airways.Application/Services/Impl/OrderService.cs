using Airways.Application.DTO;
using Airways.Application.Models;
using Airways.Application.Models.Order;
using Airways.DataAccess.Repository;
using AutoMapper;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Airways.Application.Services.Impl
{
    public class OrderService:IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly IConnectionMultiplexer _redis;

        public OrderService(IOrderRepository orderRepository,
            IMapper mapper, IConnectionMultiplexer redis)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _redis = redis;
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
            var todoItem = _mapper.Map<Core.Entity.Order>(createTodoItemModel);

            var res = await _orderRepository.AddAsync(todoItem);

            if (res == null) return null;

            var db = _redis.GetDatabase();

            var id = Guid.NewGuid();

            var data = new RedisValues(id);

            var jsonData = JsonConvert.SerializeObject(data);

            db.StringSet(id.ToString(), jsonData);

            return new CreateOrderResponceModel
            {
                Id = Guid.Parse(id.ToString())
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
