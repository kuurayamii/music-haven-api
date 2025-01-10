using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MusicHaven.Models;

namespace MusicHaven.Service
{
    public class ReviewService(MusicContext dbContext) : IReviewService
    {
        private readonly MusicContext context = dbContext;

        public IEnumerable<Review> GetReviews() 
        {
            // Apliqué la inclusión multi nivel... interesante.

            return context.Reviews
                .Include(review => review.Album)
                    .ThenInclude(album => album.TipoAlbum)
                .ToList();

        }

        // Obtener una review en especifico
        public async Task<Review> GetReview(int idPostReview)
        {
            return await context.Reviews
                .Include(review => review.Album)
                    .ThenInclude(album => album.TipoAlbum)
                .FirstOrDefaultAsync(review => review.ReviewId == idPostReview);

        }

        // Postear Review
        public async Task PostReview(Review review) 
        {
            context.Reviews.Add(review);
            await context.SaveChangesAsync();

        }

        // Editar Review
        public async Task<Review> PutReview(int idPostReview, Review review)
        {
            // TODO: ver si puedo utilizar el metodo de get para almacenarlo en una variable y modificar desde ahi.

            var reviewAEditar = await context.Reviews.FindAsync(idPostReview);

            if (reviewAEditar == null) 
            {
                return null;
            }

            reviewAEditar.TituloReview = review.TituloReview;
            reviewAEditar.CuerpoReview = review.CuerpoReview;
            reviewAEditar.Rating = review.Rating;
            await context.SaveChangesAsync();

            return reviewAEditar;

        }

        // Eliminar Review
        public async Task<Review?> DeleteReview(int idPostReview)
        {

            var reviewAEliminar = await context.Reviews.FindAsync(idPostReview);

            if (reviewAEliminar == null) 
            {
                return null;
            };

            context.Reviews.Remove(reviewAEliminar);
            context.SaveChangesAsync();

            return reviewAEliminar;
            
        }
    }

    public interface IReviewService 
    {
        IEnumerable<Review> GetReviews();
        Task<Review> GetReview(int idPostReview);
        Task PostReview(Review review);
        Task<Review> PutReview(int idPostReview, Review review);
        Task<Review?> DeleteReview(int idPostReview);
    }
}
