using RatingApp.Database;
using RatingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatingApp.Interfaces
{
    public interface IBlogController
    {
        public Blog GetBlog(string slug);

        public BlogComment AddBlogCommentToDatabase(BlogCommentSaveModel blogCommentSaveModel, User user);

        public BlogCommentsRating AddBlogCommentsRatingToDatabase(BlogCommentSaveModel blogCommentSaveModel, BlogComment blogComment, User user);
    }
}
