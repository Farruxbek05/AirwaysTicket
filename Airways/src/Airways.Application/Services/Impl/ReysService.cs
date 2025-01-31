using Airways.Application.Models.Aicraft;
using Airways.Application.Models;
using Airways.Core.Entity;
using Airways.DataAccess.Repository;
using AutoMapper;
using Airways.Application.Models.Reys;
using Airways.DataAccess.Repository.Impl;

namespace Airways.Application.Services.Impl
{
    public class ReysService:IReysService
    {
        private readonly IMapper _mapper;
        private readonly IReysRepository _reysrepository;

        public ReysService(IReysRepository reysRepository,
            IMapper mapper)
        {
            _reysrepository = reysRepository;
            _mapper = mapper;
        }

        public async Task<List<ReysResponceModel>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var result = await _reysrepository.GetAllAsync();

            var mapper = _mapper.Map<List<ReysResponceModel>>(result);
            return mapper;
        }

        public async Task<CreateReysResponceModel> CreateAsync(CreateReysModel createTodoItemModel,
            CancellationToken cancellationToken = default)
        {
            var todoItem = _mapper.Map<Reys>(createTodoItemModel);
            var res = await _reysrepository.AddAsync(todoItem);
            if (res == null) return null;
            return new CreateReysResponceModel
            {
                Id = res.Id
            };
        }

        public async Task<UpdateReysResponceModel> UpdateAsync(Guid id, UpdateReysModel updateTodoItemModel,
            CancellationToken cancellationToken = default)
        {
            var todoItem = await _reysrepository.GetFirstAsync(ti => ti.Id == id);

            _mapper.Map(updateTodoItemModel, todoItem);

            return new UpdateReysResponceModel
            {
                Id = (await _reysrepository.UpdateAsync(todoItem)).Id
            };
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var todoItem = await _reysrepository.GetFirstAsync(ti => ti.Id == id);
            if (todoItem == null) return false;

            await _reysrepository.DeleteAsync(todoItem);

            return true;
        }

    }
}
