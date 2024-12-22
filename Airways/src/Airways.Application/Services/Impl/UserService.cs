using Airways.Application.Models.Aicraft;
using Airways.Application.Models;
using Airways.Core.Entity;
using Airways.DataAccess.Repository;
using AutoMapper;
using Airways.Application.Models.User;

namespace Airways.Application.Services.Impl
{
    public class UserService:IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _usertrepository;

        public UserService(IUserRepository userRepository,
            IMapper mapper)
        {
            _usertrepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserResponceModel>> GetAllByListIdAsync(Guid id,
            CancellationToken cancellationToken = default)
        {
            var todoItems = await _usertrepository.GetAllAsync(ti => ti.Id == id);

            return _mapper.Map<IEnumerable<UserResponceModel>>(todoItems);
        }

        public async Task<CreateUserResponceModel> CreateAsync(CreateUserModel createTodoItemModel,
            CancellationToken cancellationToken = default)
        {
            var todoItem = _mapper.Map<User>(createTodoItemModel);

            return new CreateUserResponceModel
            {
                Id = (await _usertrepository.AddAsync(todoItem)).Id
            };
        }

        public async Task<UpdateusrResponceModel> UpdateAsync(Guid id, UpdateUserModel updateTodoItemModel,
            CancellationToken cancellationToken = default)
        {
            var todoItem = await _usertrepository.GetFirstAsync(ti => ti.Id == id);

            _mapper.Map(updateTodoItemModel, todoItem);

            return new UpdateusrResponceModel
            {
                Id = (await _usertrepository.UpdateAsync(todoItem)).Id
            };
        }

        public async Task<BaseResponceModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var todoItem = await _usertrepository.GetFirstAsync(ti => ti.Id == id);

            return new BaseResponceModel
            {
                Id = (await _usertrepository.DeleteAsync(todoItem)).Id
            };
        }
    }
}
