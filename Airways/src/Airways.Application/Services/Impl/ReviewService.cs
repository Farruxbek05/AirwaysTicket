using Airways.Application.Models.Airline;
using Airways.Application.Models;
using Airways.Core.Entity;
using Airways.DataAccess.Repository;
using AutoMapper;
using Airways.Application.Models.Review;

namespace Airways.Application.Services.Impl
{
    public class ReviewService:IReviewservice
    {
        private readonly IMapper _mapper;
        private readonly IReviewRepository _reviewRepository;


        public ReviewService(IReviewRepository reviewRepository,
            IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReviewResponceModel>> GetAllByListIdAsync(Guid id,
            CancellationToken cancellationToken = default)
        {
            var todoItems = await _reviewRepository.GetAllAsync(ti => ti.Id == id);

            return _mapper.Map<IEnumerable<ReviewResponceModel>>(todoItems);
        }

        public async Task<CreateReviewResponceModel> CreateAsync(CreateReviewModel createTodoItemModel,
            CancellationToken cancellationToken = default)
        {
            var todoItem = _mapper.Map<Review>(createTodoItemModel);


            return new CreateReviewResponceModel
            {
                Id = (await _reviewRepository.AddAsync(todoItem)).Id
            };
        }

        public async Task<UpdateReviewResponceModel> UpdateAsync(Guid id, UpdateReviewModel updateTodoItemModel,
            CancellationToken cancellationToken = default)
        {
            var todoItem = await _reviewRepository.GetFirstAsync(ti => ti.Id == id);

            _mapper.Map(updateTodoItemModel, todoItem);

            return new UpdateReviewResponceModel
            {
                Id = (await _reviewRepository.UpdateAsync(todoItem)).Id
            };
        }

        public async Task<BaseResponceModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var todoItem = await _reviewRepository.GetFirstAsync(ti => ti.Id == id);

            return new BaseResponceModel
            {
                Id = (await _reviewRepository.DeleteAsync(todoItem)).Id
            };
        }
    }
}
