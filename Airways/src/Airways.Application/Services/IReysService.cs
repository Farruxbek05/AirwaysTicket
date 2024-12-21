using Airways.Application.Models;
using Airways.Application.Models.Reys;

namespace Airways.Application.Services
{
    public interface IReysService
    {
        Task<CreateReysResponceModel> CreateAsync(CreateReysModel createTodoItemModel,
      CancellationToken cancellationToken = default);

        Task<BaseResponceModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        Task<IEnumerable<ReysResponceModel>>
            GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<UpdateReysResponceModel> UpdateAsync(Guid id, UpdateReysModel updateTodoItemModel,
            CancellationToken cancellationToken = default);
    }
}
