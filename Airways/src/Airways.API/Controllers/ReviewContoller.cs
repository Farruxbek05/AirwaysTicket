using Airways.Application.Models;
using Airways.Application.Models.Review;
using Airways.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Airways.API.Controllers
{
    public class ReviewContoller : ApiController
    {
        private readonly IReviewservice _reviewService;

        public ReviewContoller(IReviewservice reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateReviewModel createUserModel)
        {
            return Ok(ApiResult<CreateReviewResponceModel>.Success(
                await _reviewService.CreateAsync(createUserModel)));
        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateReviewModel updateUserModel)
        {
            return Ok(ApiResult<UpdateReviewResponceModel>.Success(
                await _reviewService.UpdateAsync(id, updateUserModel)));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            return Ok(ApiResult<BaseResponceModel>.Success(await _reviewService.DeleteAsync(id)));
        }
    }
}
