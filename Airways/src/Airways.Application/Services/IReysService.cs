using Airways.Application.Models;
using Airways.Application.Models.Aicraft;
using Airways.Application.Models.Reys;

namespace Airways.Application.Services
{
    public interface IReysService
    {
        Task<CreateReysResponceModel> CreateAsync(CreateReysModel createTodoItemModel,
      CancellationToken cancellationToken = default);

        Task<BaseResponceModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        Task<List<ReysResponceModel>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<UpdateReysResponceModel> UpdateAsync(Guid id, UpdateReysModel updateTodoItemModel,
            CancellationToken cancellationToken = default);
    }
}
