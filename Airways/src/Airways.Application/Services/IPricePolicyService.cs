using Airways.Application.Models;
using Airways.Application.Models.Aicraft;
using Airways.Application.Models.PricePolycy;

namespace Airways.Application.Services
{
    public interface IPricePolicyService
    {
        Task<CreatePricePolicyResponceModel> CreateAsync(CreatePricePolicyModel createTodoItemModel,
      CancellationToken cancellationToken = default);

        Task<BaseResponceModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        Task<List<PricePolicyResponceModel>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<UpdatePricePolicyResponceModel> UpdateAsync(Guid id, UpdatePricePolicyModel updateTodoItemModel,
            CancellationToken cancellationToken = default);
     

    }
}
