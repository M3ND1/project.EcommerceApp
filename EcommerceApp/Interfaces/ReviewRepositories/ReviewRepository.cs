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

        public void CreateReview(Review review)
        {
            var newReview = new Review
            {
                UserId = review.UserId,
                Text = review.Text,
                Rating = review.Rating,
                CreatedDate = DateTime.UtcNow,
                ProductId = review.ProductId
            };
            _context.Reviews.Add(newReview);
            _context.SaveChanges();
        }

        public bool DeleteReview(int id)
        {
            var existingReview = _context.Reviews.FirstOrDefault(r => r.Id  == id); 
            if(existingReview != null)
            {
                _context.Reviews.Remove(existingReview); 
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public ICollection<Review> GetAllReviews()
        {
            ICollection<Review> reviews = _context.Reviews.ToList();
            return reviews;
        }

        public Review SearchById(int id)
        {
            return _context.Reviews.FirstOrDefault(r => r.Id == id)!;
        }

        public bool UpdateReview(int id)
        {
            throw new NotImplementedException();
        }
    }
}
