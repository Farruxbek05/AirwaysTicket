using Airways.Core.Entity;
using Airways.DataAccess.Persistence;

namespace Airways.DataAccess.Repository.Impl
{
    public class ReviewRepository:BaseRepository<Review>,IReviewRepository
    {
        public ReviewRepository(DataBaseContext context) : base(context) { }
    }
}
