using Airways.Application.Models;
using Airways.Application.Models.Aicraft;
using Airways.Core.Entity;
using Airways.DataAccess.Repository;
using AutoMapper;

namespace Airways.Application.Services.Impl
{
    public class AicraftService : IAircraftService
    {
        private readonly IMapper _mapper;
        private readonly IAircraftRepository _aicraftrepository;

        public AicraftService(IAircraftRepository aicraftRepository,
            IMapper mapper)
        {
            _aicraftrepository = aicraftRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AicraftResponceModel>> GetAllByListIdAsync(Guid id,
            CancellationToken cancellationToken = default)
        {
            var todoItems = await _aicraftrepository.GetAllAsync(ti => ti.Airline.Id == id);


            return _mapper.Map<IEnumerable<AicraftResponceModel>>(todoItems);
        }

        public async Task<CreateAicraftResponceModel> CreateAsync(CreateAircraftModel createTodoItemModel,
            CancellationToken cancellationToken = default)
        {
            var todoItem = _mapper.Map<Aicraft>(createTodoItemModel);

            return new CreateAicraftResponceModel
            {
                Id = (await _aicraftrepository.AddAsync(todoItem)).Id
            };
        }

        public async Task<UpdateAicraftResponceModel> UpdateAsync(Guid id, UpdateAicraftModel updateTodoItemModel,
            CancellationToken cancellationToken = default)
        {
            var todoItem = await _aicraftrepository.GetFirstAsync(ti => ti.Airline.Id == id);

            _mapper.Map(updateTodoItemModel, todoItem);

            return new UpdateAicraftResponceModel
            {
                Id = (await _aicraftrepository.UpdateAsync(todoItem)).Id
            };
        }

        public async Task<BaseResponceModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var todoItem = await _aicraftrepository.GetFirstAsync(ti => ti.Id == id);

            return new BaseResponceModel
            {
                Id = (await _aicraftrepository.DeleteAsync(todoItem)).Id
            };
        }
    }
}
