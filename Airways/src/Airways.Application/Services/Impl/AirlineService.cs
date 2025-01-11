using Airways.Application.Models;
using Airways.Application.Models.Airline;
using Airways.Core.Entity;
using Airways.DataAccess.Repository;
using AutoMapper;

namespace Airways.Application.Services.Impl
{
    public class AirlineService : IAirlineService
    {
        private readonly IMapper _mapper;
        private readonly IAirlineRepository _airlineRepository;


        public AirlineService(IAirlineRepository airlineRepository,
            IMapper mapper)
        {
            _airlineRepository = airlineRepository;
            _mapper = mapper;
        }

        public async Task<List<AirlineResponceModel>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var result = await _airlineRepository.GetAllAsync();

            var mapper = _mapper.Map<List<AirlineResponceModel>>(result);
            return mapper;
        }

        public async Task<CreateAirlineResponceModel> CreateAsync(CreateAirlineModel createTodoItemModel,
            CancellationToken cancellationToken = default)
        {
            var todoItem = _mapper.Map<Airline>(createTodoItemModel);


            return new CreateAirlineResponceModel
            {
                Id = (await _airlineRepository.AddAsync(todoItem)).Id
            };
        }

        public async Task<UpdateAirlineResponceModel> UpdateAsync(Guid id, UpdateAirlineModel updateTodoItemModel,
            CancellationToken cancellationToken = default)
        {
            var todoItem = await _airlineRepository.GetFirstAsync(ti => ti.Id == id);

            _mapper.Map(updateTodoItemModel, todoItem);

            return new UpdateAirlineResponceModel
            {
                Id = (await _airlineRepository.UpdateAsync(todoItem)).Id
            };
        }

        public async Task<BaseResponceModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var todoItem = await _airlineRepository.GetFirstAsync(ti => ti.Id == id);

            return new BaseResponceModel
            {
                Id = (await _airlineRepository.DeleteAsync(todoItem)).Id
            };
        }

        public Task<IEnumerable<AirlineResponceModel>> GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
