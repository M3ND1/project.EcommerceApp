using EcommerceApp.Data;
using EcommerceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Interfaces.ReviewRepositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly AppDbContext _context;
        public ReviewRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateReviewAsync(Review review)
        {
            var newReview = new Review
            {
                UserId = review.UserId,
                Text = review.Text,
                Rating = review.Rating,
                CreatedDate = DateTime.UtcNow,
                ProductId = review.ProductId
            };
            await _context.Reviews.AddAsync(newReview);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteReviewAsync(int id)
        {
            var existingReview = await _context.Reviews.FirstOrDefaultAsync(r => r.Id  == id); 
            if(existingReview != null)
            {
                _context.Reviews.Remove(existingReview); 
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<ICollection<Review>> GetAllReviewsAsync()
        {
            ICollection<Review> reviews = await _context.Reviews.ToListAsync();
            return reviews;
        }

        public async Task<Review> SearchByIdAsync(int id)
        {
            return await _context.Reviews.FirstOrDefaultAsync(r => r.Id == id)!;
        }

        public Task<bool> UpdateReviewAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
