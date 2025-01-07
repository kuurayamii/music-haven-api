using Microsoft.AspNetCore.Mvc;
using MusicHaven.Models;
using MusicHaven.Service;

namespace MusicHaven.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController(IReviewService service) : ControllerBase
    {
        IReviewService reviewService = service;

        // Obtener todas las reviews
        [HttpGet]
        public IActionResult GetReviews()
        {
            return Ok(reviewService.GetReviews());
        }

        // Obtener una sola review
        [HttpGet("{id}")]
        public async Task <IActionResult> GetReview(int id)
        {
            var review = await reviewService.GetReview(id);

            if (review == null) return NotFound();

            return Ok(review);
        }

        // Registrar una opinion / review
        [HttpPost]
        public async Task <IActionResult> PostReview(Review review)
        {
            await reviewService.PostReview(review);
            return Ok();
        }

        // Modificar review
        [HttpPut("{id}")]
        public async Task <IActionResult> PutReview(int id, Review review)
        {
            throw new NotImplementedException();
        }

        // Elimnar review
        [HttpDelete("{id}")]
        public async Task <IActionResult> DeleteReview(int id)
        {
            throw new NotImplementedException();
        }
    }
}
