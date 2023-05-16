using EcommerceApp.Models;

namespace EcommerceApp.Interfaces.ReviewRepositories
{
    public interface IReviewRepository
    {
        public ICollection<Review> GetAllReviews();
        public void CreateReview(Review review);
        public bool UpdateReview(int id);
        public bool DeleteReview(int id);
        public Review SearchById(int id);
    }
}
