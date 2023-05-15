using EcommerceApp.Models;

namespace EcommerceApp.Interfaces.ReviewRepositories
{
    public interface IReviewRepository
    {
        public ICollection<Review> GetAllReviews();
    }
}
