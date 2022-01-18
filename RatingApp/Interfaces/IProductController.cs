using RatingApp.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatingApp.Interfaces
{
    public interface IProductController
    {
        public Product GetProduct(string slug);

        public ProductsRating AddProductsRatingToDatabase(int productId, int rating, int userId);

        public ProductsRating UpdateProductsRatingToDatabase(int userId, int productId, int rating);

        public ProductsRating CheckRatingForUser(int userId, int productId);

        public User GetUser();

    }
}
