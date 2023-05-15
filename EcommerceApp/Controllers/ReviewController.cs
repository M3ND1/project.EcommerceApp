using EcommerceApp.Interfaces.ReviewRepositories;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewRepository _reviewRepository;
        public ReviewController(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }
        public IActionResult Index()
        {
            var data = _reviewRepository.GetAllReviews();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
