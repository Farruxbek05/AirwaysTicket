using Airways.Application.Models;
using Airways.Application.Models.Classs;
using Airways.Core.Entity;
using Airways.DataAccess.Repository;
using AutoMapper;

namespace Airways.Application.Services.Impl
{
    public class ClassService : IClassService
    {
        private readonly IMapper _mapper;
        private readonly IClassRepository _classRepository;


        public ClassService(IClassRepository classRepository,
            IMapper mapper)
        {
            _classRepository = classRepository;
            _mapper = mapper;
        }

        public async Task<List<ClassResponceModel>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var result = await _classRepository.GetAllAsync();

            var mapper = _mapper.Map<List<ClassResponceModel>>(result);
            return mapper;
        }

        public async Task<CreateClassResponceModel> CreateAsync(CreateCLassModel createTodoItemModel,
            CancellationToken cancellationToken = default)
        {
            var todoItem = _mapper.Map<Class>(createTodoItemModel);

            var res = await _classRepository.AddAsync(todoItem);
            if (res == null) return null;
            return new CreateClassResponceModel
            {
                Id = res.Id
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
