using Airways.Application.Models;
using Airways.Application.Models.Payment;

namespace Airways.Application.Services
{
    public interface IPaymentService
    {
        Task<CreatePaymentResponceModel> CreateAsync(CreatePaymentModel createTodoItemModel,
      CancellationToken cancellationToken = default);

        Task<BaseResponceModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        Task<IEnumerable<PaymentResponceModel>>
            GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<UpdatePaymentResponceModel> UpdateAsync(Guid id, UpdatePaymentModel updateTodoItemModel,
            CancellationToken cancellationToken = default);
    }
}
