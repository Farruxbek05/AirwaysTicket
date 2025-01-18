using Airways.Application.Models;
using Airways.Application.Models.Payment;
using Airways.Core.Entity;
using Airways.DataAccess.Repository;
using AutoMapper;
namespace Airways.Application.Services.Impl
{
    public class PaymentService : IPaymentService
    {
        private readonly IMapper _mapper;
        private readonly IPaymentRepository _paymentRepository;


        public PaymentService(IPaymentRepository paymentRepository,
            IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<List<PaymentResponceModel>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var result = await _paymentRepository.GetAllAsync();

            var mapper = _mapper.Map<List<PaymentResponceModel>>(result);
            return mapper;
        }
        public async Task<CreatePaymentResponceModel> CreateAsync(CreatePaymentModel createTodoItemModel,
            CancellationToken cancellationToken = default)
        {
            var todoItem = _mapper.Map<Payment>(createTodoItemModel);
            var responce = await _paymentRepository.AddAsync(todoItem);
            if (responce == null) return null;


            return new CreatePaymentResponceModel
            {
                Id = responce.Id
            };
        }

        public async Task<UpdatePaymentResponceModel> UpdateAsync(Guid id, UpdatePaymentModel updateTodoItemModel,
            CancellationToken cancellationToken = default)
        {
            var todoItem = await _paymentRepository.GetFirstAsync(ti => ti.Id == id);

            _mapper.Map(updateTodoItemModel, todoItem);

            return new UpdatePaymentResponceModel
            {
                Id = (await _paymentRepository.UpdateAsync(todoItem)).Id
            };
        }

        public async Task<BaseResponceModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var todoItem = await _paymentRepository.GetFirstAsync(ti => ti.Id == id);

            return new BaseResponceModel
            {
                Id = (await _paymentRepository.DeleteAsync(todoItem)).Id
            };
        }
    }
}
