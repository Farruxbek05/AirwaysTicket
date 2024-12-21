using Airways.Application.Models.Airline;
using Airways.Application.Models;
using Airways.Core.Entity;
using Airways.DataAccess.Repository;
using AutoMapper;
using Airways.Application.Models.Payment;
using Airways.Application.Models.Aicraft;

namespace Airways.Application.Services.Impl
{
    public class PaymentService :IPaymentService
    {
        private readonly IMapper _mapper;
        private readonly IPaymentRepository _paymentRepository;


        public PaymentService(IPaymentRepository paymentRepository,
            IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PaymentResponceModel>> GetAllByListIdAsync(Guid id,
            CancellationToken cancellationToken = default)
        {
            var todoItems = await _paymentRepository.GetAllAsync(ti => ti.Id == id);

            return _mapper.Map<IEnumerable<PaymentResponceModel>>(todoItems);
        }

        public async Task<CreatePaymentResponceModel> CreateAsync(CreatePaymentModel createTodoItemModel,
            CancellationToken cancellationToken = default)
        {
            var todoItem = _mapper.Map<Payment>(createTodoItemModel);


            return new CreatePaymentResponceModel
            {
                Id = (await _paymentRepository.AddAsync(todoItem)).Id
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
