using Airways.Application.Models.Aicraft;
using Airways.Application.Models;
using Airways.Core.Entity;
using Airways.DataAccess.Repository;
using AutoMapper;
using Airways.Application.Models.Reys;

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

        public async Task<IEnumerable<ReysResponceModel>> GetAllByListIdAsync(Guid id,
            CancellationToken cancellationToken = default)
        {
            var todoItems = await _reysrepository.GetAllAsync(ti => ti.Id == id);

            return _mapper.Map<IEnumerable<ReysResponceModel>>(todoItems);
        }

        public async Task<CreateReysResponceModel> CreateAsync(CreateReysModel createTodoItemModel,
            CancellationToken cancellationToken = default)
        {
            var todoItem = _mapper.Map<Reys>(createTodoItemModel);

            return new CreateReysResponceModel
            {
                Id = (await _reysrepository.AddAsync(todoItem)).Id
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

        public async Task<BaseResponceModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var todoItem = await _reysrepository.GetFirstAsync(ti => ti.Id == id);

            return new BaseResponceModel
            {
                Id = (await _reysrepository.DeleteAsync(todoItem)).Id
            };
        }
    }
}
