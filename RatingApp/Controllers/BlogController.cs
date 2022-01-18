using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RatingApp.Database;
using RatingApp.Interfaces;
using RatingApp.Models;
using RatingApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RatingApp.Controllers
{
    public class BlogController : Controller
    {
        RatingAppDBContext _context;
        SingleBlogPageModel singleBlogPageModel = new SingleBlogPageModel();
        IBlogController _blogController;
        IHttpContextAccessor _httpContextAccessor;


        public BlogController(RatingAppDBContext context, IHttpContextAccessor httpContextAccessor, IBlogController blogController)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _blogController = blogController;
        }

        public IActionResult Index()
        {
            // ToDo:
            // get all blogs
            return View();
        }

        public IActionResult SingleBlog(string slug)
        {
            singleBlogPageModel.Blog = _blogController.GetBlog(slug);
            return View(singleBlogPageModel);
        }

        public JsonResult SaveBlogComment(BlogCommentSaveModel blogCommentSaveModel)
        {
            string result = "0";

            BlogComment blogComment = new BlogComment();
            BlogCommentsRating blogCommentsRating = new BlogCommentsRating();
            User user = new User();

            var checkUser = _context.Users.Where(x => x.Email == blogCommentSaveModel.Email).FirstOrDefault();

            if (checkUser != null)
            {
                blogComment = _blogController.AddBlogCommentToDatabase(blogCommentSaveModel, checkUser);
                blogCommentsRating = _blogController.AddBlogCommentsRatingToDatabase(blogCommentSaveModel, blogComment, checkUser);

                result = "1";
            }
            else
            {
                result = "-1";
            }

            return Json(result);
        }
    }
}





