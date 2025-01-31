using Airways.Application.Models;
using Airways.Application.Models.Aicraft;
using Airways.Application.Models.Classs;

namespace Airways.Application.Services
{
    public interface IClassService
    {
        Task<List<ClassResponceModel>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<CreateClassResponceModel> CreateAsync(CreateCLassModel createTodoItemModel,
      CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(Guid id);


        Task<UpdateClassResponceModel> UpdateAsync(Guid id, UpdateClassModel updateTodoItemModel,
            CancellationToken cancellationToken = default);
    }
}
