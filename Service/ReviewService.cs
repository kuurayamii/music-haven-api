using MusicHaven.Models;

namespace MusicHaven.Service
{
    public class ReviewService(MusicContext dbContext)
    {
        private readonly MusicContext context = dbContext;

        public IEnumerable<Review> Get() 
        {
            throw new NotImplementedException();
        }

        // Obtener una review en especifico
        public async Task<Review> GetReview(int idPostReview)
        {
            throw new NotImplementedException();
        }

        // Postear Review
        public async Task PostReview(Review review) 
        {
            throw new NotImplementedException();
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
}
