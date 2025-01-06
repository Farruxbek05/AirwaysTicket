using Airways.Application.Models;
using Airways.Application.Models.PricePolycy;
using Airways.Core.Entity;
using Airways.DataAccess.Repository;
using AutoMapper;

namespace Airways.Application.Services.Impl
{
    public class PricePolicyService : IPricePolicyService
    {
        private readonly IMapper _mapper;
        private readonly IPricePolyceRepository _pricepolicyRepository;


        public PricePolicyService(IPricePolyceRepository pricepolicyRepository,
            IMapper mapper)
        {
            _pricepolicyRepository = pricepolicyRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PricePolicyResponceModel>> GetAllByListIdAsync(Guid id,
            CancellationToken cancellationToken = default)
        {
            var todoItems = await _pricepolicyRepository.GetAllAsync(ti => ti.Id == id);

            return _mapper.Map<IEnumerable<PricePolicyResponceModel>>(todoItems);
        }

        public async Task<CreatePricePolicyResponceModel> CreateAsync(CreatePricePolicyModel createTodoItemModel,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var todoItem = _mapper.Map<PricePolicy>(createTodoItemModel);

                return new CreatePricePolicyResponceModel
                {
                    Id = (await _pricepolicyRepository.AddAsync(todoItem)).Id
                };
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<UpdatePricePolicyResponceModel> UpdateAsync(Guid id, UpdatePricePolicyModel updateTodoItemModel,
            CancellationToken cancellationToken = default)
        {
            var todoItem = await _pricepolicyRepository.GetFirstAsync(ti => ti.Id == id);

            _mapper.Map(updateTodoItemModel, todoItem);

            return new UpdatePricePolicyResponceModel
            {
                Id = (await _pricepolicyRepository.UpdateAsync(todoItem)).Id
            };
        }

        public async Task<BaseResponceModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var todoItem = await _pricepolicyRepository.GetFirstAsync(ti => ti.Id == id);

            return new BaseResponceModel
            {
                Id = (await _pricepolicyRepository.DeleteAsync(todoItem)).Id
            };
        }

        
    }
}
