using Airways.Application.Models;
using Airways.Core.Common;
using Airways.DataAccess.Repository;
using MediatR;
namespace Airways.Application.MediatrCRUD
{
    public record DeletePersonCommand(int Id) : IRequest<ApiResult>;

    public class DeletePersonHandler : IRequestHandler<DeletePersonCommand, ApiResult>
    {
        private readonly IPersonRepository _repository;

        public DeletePersonHandler(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResult> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            // ID bo'yicha shaxsni olish
            var person = await _repository.GetByIdAsync(request.Id);
            if (person == null)
                return ApiResult.Failure(Error.NotFound, "Person not found");

            // Personni o'chirish
            var success = await _repository.DeleteAsync(request.Id);
            if (!success)
                return ApiResult.Failure(Error.DatabaseError, "Failed to delete person");

            // Muvaffaqiyatli o'chirish
            return ApiResult.Success("Person successfully deleted.");
        }
    }


}
