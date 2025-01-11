using Airways.Application.Models;
using Airways.Application.Models.Aicraft;
using Airways.Application.Models.Order;

namespace Airways.Application.Services
{
    public interface IOrderService
    {
        Task<CreateOrderResponceModel> CreateAsync(CreateOrderModel createTodoItemModel,
      CancellationToken cancellationToken = default);

        Task<BaseResponceModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        Task<List<OrderResponceModel>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<UpdateOrderResponceModel> UpdateAsync(Guid id, UpdateOrderModel updateTodoItemModel,
            CancellationToken cancellationToken = default);
    }
}
