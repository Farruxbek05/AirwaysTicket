using Airways.Application.Models;
using Airways.Application.Models.Aicraft;

namespace Airways.Application.Services
{
    public interface IAircraftService
    {
        Task<List<AicraftResponceModel>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<CreateAicraftResponceModel> CreateAsync(CreateAircraftModel createTodoItemModel,
      CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(Guid id);

        Task<IEnumerable<AicraftResponceModel>>
            GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<UpdateAicraftResponceModel> UpdateAsync(Guid id, UpdateAicraftModel updateTodoItemModel,
            CancellationToken cancellationToken = default);

    }
}
