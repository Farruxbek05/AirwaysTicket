using Airways.Application.Models;
using Airways.Core.Common;
using Airways.DataAccess.Repository;
using MediatR;
namespace Airways.Application.MediatrCRUD
{

    public record UpdatePersonCommand(int Id, string FirstName, string LastName) : IRequest<ApiResult>;

    public class UpdatePersonHandler : IRequestHandler<UpdatePersonCommand, ApiResult>
    {
        private readonly IPersonRepository _repository;

        public UpdatePersonHandler(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResult> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _repository.GetByIdAsync(request.Id);
            if (person == null)
                return ApiResult.Failure(Error.NotFound, "Person not found");

            person.FirstName = request.FirstName;
            person.LastName = request.LastName;

            var success = await _repository.UpdateAsync(person);
            if (!success)
                return ApiResult.Failure(Error.DatabaseError, "Failed to update person");

            return ApiResult.Success("Person successfully updated.");
        }
    }


}
