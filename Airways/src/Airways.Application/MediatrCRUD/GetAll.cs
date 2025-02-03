using Airways.Application.Models;
using Airways.Application.Services;
using Airways.Core.Common;
using Airways.Core.Entity;
using MediatR;
namespace Airways.Application.MediatrCRUD
{

    public record GetAllPersonsQuery() : IRequest<ApiResult<List<Person>>>;

    public class GetAllPersonsHandler : IRequestHandler<GetAllPersonsQuery, ApiResult<List<Person>>>
    {
        private readonly IPersonService _service;

        public GetAllPersonsHandler(IPersonService service)
        {
            _service = service;
        }

        public async Task<ApiResult<List<Person>>> Handle(GetAllPersonsQuery request, CancellationToken cancellationToken)
        {
            var persons = await _service.GetAllPersons();

            if (persons == null || !persons.Any())
                return ApiResult<List<Person>>.Failure(Error.NotFound, "No persons found."); // ❗ Agar bo‘sh bo‘lsa, xato qaytarish

            return ApiResult<List<Person>>.Success(persons);
        }
    }


}
