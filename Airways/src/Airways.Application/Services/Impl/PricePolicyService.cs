using Airways.Application.Models;
using Airways.Application.Models.Aicraft;
using Airways.Application.Models.PricePolycy;
using Airways.Core.Entity;
using Airways.DataAccess.Repository;
using Airways.DataAccess.Repository.Impl;
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

        public async Task<List<PricePolicyResponceModel>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var result = await _pricepolicyRepository.GetAllAsync();

            var mapper = _mapper.Map<List<PricePolicyResponceModel>>(result);
            return mapper;
        }

        public async Task<CreatePricePolicyResponceModel> CreateAsync(CreatePricePolicyModel createTodoItemModel,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var todoItem = _mapper.Map<PricePolicy>(createTodoItemModel);
                var res = await _pricepolicyRepository.AddAsync(todoItem);
                if (res == null) return null;

                return new CreatePricePolicyResponceModel
                {
                    Id = res.Id
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

        public async Task<bool> DeleteAsync(Guid id)
        {
            var todoItem = await _pricepolicyRepository.GetFirstAsync(ti => ti.Id == id);
            if (todoItem == null) return false;

            await _pricepolicyRepository.DeleteAsync(todoItem);

            return true;
        }



    }
}
