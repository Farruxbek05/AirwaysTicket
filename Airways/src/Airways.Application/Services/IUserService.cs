using Airways.Application.Models;
using Airways.Application.Models.User;

namespace Airways.Application.Services
{
    public interface IUserService
    {
        Task<CreateUserResponceModel> CreateAsync(CreateUserModel createTodoItemModel,
      CancellationToken cancellationToken = default);

        Task<BaseResponceModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        Task<IEnumerable<UserResponceModel>>
            GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<UpdateusrResponceModel> UpdateAsync(Guid id, UpdateUserModel updateTodoItemModel,
            CancellationToken cancellationToken = default);
    }
}
