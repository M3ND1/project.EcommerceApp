using EcommerceApp.Models;

namespace EcommerceApp.Interfaces.ReviewRepositories
{
    public interface IReviewRepository
    {
        public Task<ICollection<Review>> GetAllReviewsAsync();
        public Task CreateReviewAsync(Review review);
        public Task<bool> UpdateReviewAsync(int id);
        public Task<bool> DeleteReviewAsync(int id);
        public Task<Review> SearchByIdAsync(int id);
    }
}
