using Airways.Application.Models;
using Airways.Application.Models.Airline;

namespace Airways.Application.Services
{
    public interface IAirlineService
    {
        Task<CreateAirlineResponceModel> CreateAsync(CreateAirlineModel createTodoItemModel,
      CancellationToken cancellationToken = default);

        Task<BaseResponceModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        Task<IEnumerable<AirlineResponceModel>>
            GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<UpdateAirlineResponceModel> UpdateAsync(Guid id, UpdateAirlineModel updateTodoItemModel,
            CancellationToken cancellationToken = default);
    }
}
