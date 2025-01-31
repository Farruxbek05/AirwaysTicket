using Airways.Application.Models;
using Airways.Application.Models.Aicraft;
using Airways.Core.Entity;
using Airways.DataAccess.Repository;
using Airways.DataAccess.Repository.Impl;
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

        public async Task<IEnumerable<AicraftResponceModel>> GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var todoItems = await _aicraftrepository.GetAllAsync( ti => ti.Id == id);


            return (IEnumerable<AicraftResponceModel>)_mapper.Map<AicraftResponceModel>(todoItems);
        }

        public async Task<CreateAicraftResponceModel> CreateAsync(CreateAircraftModel createTodoItemModel,
            CancellationToken cancellationToken = default)
        {
            var todoItem = _mapper.Map<Aicraft>(createTodoItemModel);
            var result = await _aicraftrepository.AddAsync(todoItem);

            if (result == null) return null;

            return new CreateAicraftResponceModel
            {
                Id = result.Id
            };
        }

        public async Task<UpdateAicraftResponceModel> UpdateAsync(Guid id, UpdateAicraftModel updateTodoItemModel,
            CancellationToken cancellationToken = default)
        {
            var todoItem = await _aicraftrepository.GetFirstAsync(ti => ti.Id == id);

            _mapper.Map(updateTodoItemModel, todoItem);

            return new UpdateAicraftResponceModel
            {
                Id = (await _aicraftrepository.UpdateAsync(todoItem)).Id
            };
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var todoItem = await _aicraftrepository.GetFirstAsync(ti => ti.Id == id);
            if (todoItem == null) return false;

            await _aicraftrepository.DeleteAsync(todoItem);

            return true;
        }


        public async Task<List<AicraftResponceModel>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var result = await _aicraftrepository.GetAllAsync();

            var mapper = _mapper.Map<List<AicraftResponceModel>>(result);
            return mapper;
        }
    }
}
