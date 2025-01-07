using Microsoft.EntityFrameworkCore;
using MusicHaven.Models;

namespace MusicHaven.Service
{
    public class ReviewService(MusicContext dbContext)
    {
        private readonly MusicContext context = dbContext;

        public IEnumerable<Review> GetReviews() 
        {
            return context.Reviews
                .Include(review => review.Album)
                .ToList();
            //throw new NotImplementedException();
        }

        // Obtener una review en especifico
        public async Task<Review> GetReview(int idPostReview)
        {
            return await context.Reviews
                .Include(review => review.Album)
                .FirstOrDefaultAsync(review => review.ReviewId == idPostReview);

        }

        // Postear Review
        public async Task PostReview(Review review) 
        {
            context.Reviews.Add(review);
            await context.SaveChangesAsync();

        }

        // Editar Review
        public async Task PutReview(int idPostReview, Review review)
        {
            throw new NotImplementedException();
        }
        
        // Eliminar Review
        public async Task DeleteReview(int idPostReview)
        {
            throw new NotImplementedException();
        }
    }

    public interface IReviewService 
    {
        IEnumerable<Review> GetReviews();
        Task<Review> GetReview(int idPostReview);
        Task PostReview(Review review);
        Task PutReview(int idPostReview, Review review);
        Task DeleteReview(int idPostReview);
    }
}
