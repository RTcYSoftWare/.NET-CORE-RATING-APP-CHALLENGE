using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RatingApp.Database
{
    public class BlogCommentsRating
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int BlogId { get; set; }

        [Required]
        public int BlogCommentId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int Rating { get; set; }

        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public Nullable<DateTime> UpdatedAt { get; set; }
        public Nullable<DateTime> DeletedAt { get; set; }
    }
}
