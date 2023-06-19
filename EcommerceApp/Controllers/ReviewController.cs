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
        public async Task<IActionResult> Index()
        {
            var data = await _reviewRepository.GetAllReviewsAsync();
            return View(data);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var review = await _reviewRepository.SearchByIdAsync(id);
            if(review != null)
            {
                return View(review);
            }
            return BadRequest(); //in future TODO: end of internet
        }
        public async Task<IActionResult> Details(int id)
        {
            var review = await _reviewRepository.SearchByIdAsync(id);
            if (review != null)
            {
                return View(review);
            }
            return BadRequest(); //in future TODO: end of internet
        }

        public async Task<IActionResult> Create(int Id)
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
        public async Task<IActionResult> Create([Bind("Id,UserId,Text,Rating,CreatedDate,ProductId")] Review review,int productId)
        {
            if(ModelState.IsValid)
            {
                await _reviewRepository.CreateReviewAsync(review);
                return RedirectToAction("Details", "Product", new { id = productId });
                //product Details id 
            }
            else
            {
                return BadRequest();
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            var review = await _reviewRepository.SearchByIdAsync(id);
            if (review != null)
            {
                return View(review);
            }
            return BadRequest(); //in future TODO: end of internet
        }
        [HttpPost]
        public async Task<IActionResult> DeleteReview(int id)
        {
            if(await _reviewRepository.DeleteReviewAsync(id))
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
