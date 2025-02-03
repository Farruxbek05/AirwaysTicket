using Airways.Application.Models;
using Airways.Core.Common;
using Airways.Core.Entity;
using Airways.DataAccess.Repository;
using MediatR;
namespace Airways.Application.MediatrCRUD
{

    public record CreatePersonCommand(string FirstName, string LastName) : IRequest<ApiResult<int>>;

    public class CreatePersonHandler : IRequestHandler<CreatePersonCommand, ApiResult<int>>
    {
        private readonly IPersonRepository _repository;

        public CreatePersonHandler(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResult<int>> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            // Agar FirstName yoki LastName bo'sh bo'lsa, failure qaytaramiz
            if (string.IsNullOrWhiteSpace(request.FirstName) || string.IsNullOrWhiteSpace(request.LastName))
                return ApiResult<int>.Failure(Error.NotFound, "First name and last name cannot be empty.");

            // Yangi person yaratish
            var person = new Person
            {
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            // Personni saqlash
            var id = await _repository.CreateAsync(person);

            // Agar id qaytmasa yoki manfiy bo'lsa, failure qaytaramiz
            if (id <= 0)
                return ApiResult<int>.Failure(Error.DatabaseError, "Failed to create person.");

            // Muvaffaqiyatli saqlashdan so'ng, id va muvaffaqiyatli xabar bilan qaytamiz
            return ApiResult<int>.Success(id, "Person successfully created.");
        }
    }


}
