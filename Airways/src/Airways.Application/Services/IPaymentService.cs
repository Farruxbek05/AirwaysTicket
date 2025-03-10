﻿using Airways.Application.Models;
using Airways.Application.Models.Aicraft;
using Airways.Application.Models.Payment;

namespace Airways.Application.Services
{
    public interface IPaymentService
    {
        Task<CreatePaymentResponceModel> CreateAsync(CreatePaymentModel createTodoItemModel,
      CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(Guid id);

        Task<List<PaymentResponceModel>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<UpdatePaymentResponceModel> UpdateAsync(Guid id, UpdatePaymentModel updateTodoItemModel,
            CancellationToken cancellationToken = default);
    }
}
