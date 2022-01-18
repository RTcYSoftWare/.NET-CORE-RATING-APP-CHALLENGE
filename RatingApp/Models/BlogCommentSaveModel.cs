using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatingApp.Models
{
    public class BlogCommentSaveModel
    {
        public int BlogId { get; set; }
        public string Email { get; set; }
        public string NameSurname{ get; set; }
        public string Message { get; set; }
        public int Rating { get; set; }
    }
}
