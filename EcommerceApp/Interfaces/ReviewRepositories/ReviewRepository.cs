using EcommerceApp.Data;
using EcommerceApp.Models;

namespace EcommerceApp.Interfaces.ReviewRepositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly AppDbContext _context;
        public ReviewRepository(AppDbContext context)
        {
            _context = context;
        }
        public ICollection<Review> GetAllReviews()
        {
            ICollection<Review> reviews = _context.Reviews.ToList();
            return reviews;
        }
    }
}
