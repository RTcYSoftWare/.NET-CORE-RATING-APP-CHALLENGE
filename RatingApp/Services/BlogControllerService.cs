using Microsoft.EntityFrameworkCore;
using RatingApp.Database;
using RatingApp.Interfaces;
using RatingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatingApp.Services
{
    public class BlogControllerService : IBlogController
    {
        RatingAppDBContext _context;


        public BlogControllerService(RatingAppDBContext context)
        {
            _context = context;
        }

        public Blog GetBlog(string slug)
        {
            Blog blog = new Blog();

            blog = _context.Blogs.AsNoTracking()
                .Include(x => x.BlogCategory)
                .Include(x => x.BlogComments).ThenInclude(y => y.BlogCommentsRating)
                .Include(x => x.BlogComments).ThenInclude(u => u.User)
                .Where(x => x.Status == true && x.DeletedAt == null && x.Slug == slug)
                .FirstOrDefault();

            return blog;
        }

        public BlogComment AddBlogCommentToDatabase(BlogCommentSaveModel blogCommentSaveModel, User user)
        {
            BlogComment blogComment = new BlogComment();

            blogComment.BlogId = blogCommentSaveModel.BlogId;
            blogComment.UserId = user.Id;
            blogComment.Text = blogCommentSaveModel.Message;
            blogComment.Status = true;
            blogComment.CreatedAt = DateTime.Now;
            _context.BlogComments.Add(blogComment);
            _context.SaveChanges();

            return blogComment;
        }

        public BlogCommentsRating AddBlogCommentsRatingToDatabase(BlogCommentSaveModel blogCommentSaveModel, BlogComment blogComment, User user)
        {
            BlogCommentsRating blogCommentsRating = new BlogCommentsRating();
            blogCommentsRating.BlogId = blogCommentSaveModel.BlogId;
            blogCommentsRating.UserId = user.Id;
            blogCommentsRating.BlogCommentId = blogComment.Id;
            blogCommentsRating.Rating = blogCommentSaveModel.Rating;
            blogCommentsRating.Status = true;
            blogCommentsRating.CreatedAt = DateTime.Now;

            _context.BlogCommentsRatings.Add(blogCommentsRating);
            _context.SaveChanges();

            return blogCommentsRating;
        }


    }
}
