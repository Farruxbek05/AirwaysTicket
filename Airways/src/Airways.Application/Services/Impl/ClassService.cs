using Airways.Application.Models.Airline;
using Airways.Application.Models;
using Airways.Core.Entity;
using Airways.DataAccess.Repository;
using AutoMapper;
using Airways.Application.Models.Classs;

namespace Airways.Application.Services.Impl
{
    public class ClassService:IClassService
    {
        private readonly IMapper _mapper;
        private readonly IClassRepository _classRepository;


        public ClassService(IClassRepository classRepository,
            IMapper mapper)
        {
            _classRepository = classRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClassResponceModel>> GetAllByListIdAsync(Guid id,
            CancellationToken cancellationToken = default)
        {
            var todoItems = await _classRepository.GetAllAsync(ti => ti.Id == id);

            return _mapper.Map<IEnumerable<ClassResponceModel>>(todoItems);
        }

        public async Task<CreateClassResponceModel> CreateAsync(CreateCLassModel createTodoItemModel,
            CancellationToken cancellationToken = default)
        {
            var todoItem = _mapper.Map<Class>(createTodoItemModel);


            return new CreateClassResponceModel
            {
                Id = (await _classRepository.AddAsync(todoItem)).Id
            };
        }

        public async Task<UpdateClassResponceModel> UpdateAsync(Guid id, UpdateClassModel updateTodoItemModel,
            CancellationToken cancellationToken = default)
        {
            var todoItem = await _classRepository.GetFirstAsync(ti => ti.Id == id);

            _mapper.Map(updateTodoItemModel, todoItem);

            return new UpdateClassResponceModel
            {
                Id = (await _classRepository.UpdateAsync(todoItem)).Id
            };
        }

        public async Task<BaseResponceModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var todoItem = await _classRepository.GetFirstAsync(ti => ti.Id == id);

            return new BaseResponceModel
            {
                Id = (await _classRepository.DeleteAsync(todoItem)).Id
            };
        }
    }
}
