using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RatingApp.Database;
using RatingApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatingApp.Services
{
    public class ProductControllerService : IProductController
    {
        RatingAppDBContext _context;        
        IHttpContextAccessor _httpContextAccessor;


        public ProductControllerService(RatingAppDBContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public Product GetProduct(string slug)
        {
            var product = _context.Products.AsNoTracking()
                .Include(x => x.ProductsRatings).ThenInclude(y => y.User)
                .Where(x => x.Slug == slug && x.Status == true && x.DeletedAt == null)
                .FirstOrDefault();

            return product;
        }

        public ProductsRating AddProductsRatingToDatabase(int productId, int rating, int userId)
        {
            ProductsRating productsRating = new ProductsRating();

            var check = CheckRatingForUser(userId, productId);

            if (check == null)
            {
                productsRating.ProductId = productId;
                productsRating.UserId = userId;
                productsRating.Rating = rating;
                productsRating.Status = true;
                productsRating.CreatedAt = DateTime.Now;

                _context.ProductsRatings.Add(productsRating);
                _context.SaveChanges();
            }
            else
            {
                UpdateProductsRatingToDatabase(userId, productId, rating);
            }

            return productsRating;
        }


        public ProductsRating UpdateProductsRatingToDatabase(int userId, int productId, int rating)
        {
            var getProductsRating = _context.ProductsRatings.Where(x => x.UserId == userId && x.ProductId == productId).FirstOrDefault();
            getProductsRating.Rating = rating;

            _context.SaveChanges();

            return getProductsRating;
        }

        public ProductsRating CheckRatingForUser(int userId, int productId)
        {
            var isFind = _context.ProductsRatings.Where(x => x.UserId == userId && x.ProductId == productId).FirstOrDefault();

            return isFind;
        }

        public string readCookie(string cookieName)
        {
            string result = "";

            string value = _httpContextAccessor.HttpContext.Request.Cookies[cookieName];

            if (value != null)
            {
                result = value.ToString();
            }

            return result;
        }

        public User GetUser()
        {
            string userGuid = readCookie("user");

            return _context.Users.Where(x => x.GUID.ToString() == userGuid).FirstOrDefault();
        }
    }
}
