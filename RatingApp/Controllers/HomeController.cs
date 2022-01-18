using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RatingApp.Database;
using RatingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatingApp.Controllers
{
    public class HomeController : Controller
    {
        RatingAppDBContext _context;
        HomePageModel homePageModel = new HomePageModel();


        public HomeController(RatingAppDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            homePageModel.Blogs = _context.Blogs.AsNoTracking()
                .Include(x => x.BlogComments).ThenInclude(y => y.BlogCommentsRating)
                .Include(x => x.BlogCategory)
                .Where(x => x.Status == true)
                .ToList();

            homePageModel.Products = _context.Products.AsNoTracking()
                .Include(x => x.ProductsRatings).ThenInclude(y => y.User)
                .Where(x => x.Status == true && x.DeletedAt == null)
                .ToList();

            return View(homePageModel);
        }
    }
}