using EcommerceApp.Interfaces.ReviewRepositories;
using EcommerceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace EcommerceApp.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly UserManager<AppUser> _userManager;
        public ReviewController(IReviewRepository reviewRepository, UserManager<AppUser> userManager)
        {
            _reviewRepository = reviewRepository;
            _userManager = userManager;

        }
        public IActionResult Index()
        {
            var data = _reviewRepository.GetAllReviews();
            return View(data);
        }
        public IActionResult Edit(int id)
        {
            var review = _reviewRepository.SearchById(id);
            if(review != null)
            {
                return View(review);
            }
            return BadRequest(); //in future TODO: end of internet
        }
        public IActionResult Details(int id)
        {
            var review = _reviewRepository.SearchById(id);
            if (review != null)
            {
                return View(review);
            }
            return BadRequest(); //in future TODO: end of internet
        }

        public IActionResult Create(int Id)
        {
            //get userId
            //string? userId = User.Identity.Name;
            string? userId = _userManager.GetUserId(User);
            if(userId == null)
            {
                userId = "";
            }
            //product that we are writing review
            var review = new Review
            {
                ProductId = Id,
                UserId = userId
            };
            return View(review);
        }
        [HttpPost]
        [ActionName("CreateReview")]
        public IActionResult Create([Bind("Id,UserId,Text,Rating,CreatedDate,ProductId")] Review review)
        {
            if(ModelState.IsValid)
            {
                _reviewRepository.CreateReview(review);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return BadRequest();
            }
        }
        public IActionResult Delete(int id)
        {
            var review = _reviewRepository.SearchById(id);
            if (review != null)
            {
                return View(review);
            }
            return BadRequest(); //in future TODO: end of internet
        }
        [HttpPost]
        public IActionResult DeleteReview(int id)
        {
            if(_reviewRepository.DeleteReview(id))
            {
                TempData["SuccessMessage"] = "Review deleted successfully";
            }
            else
            {
                TempData["FailMessage"] = "Something went wrong. Try again.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
