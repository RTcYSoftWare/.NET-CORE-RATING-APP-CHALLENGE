using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RatingApp.Database
{
    public class BlogComment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int BlogId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Column(TypeName = ("varchar(MAX)"))]
        [Required]
        public string Text { get; set; }

        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public Nullable<DateTime> UpdatedAt { get; set; }
        public Nullable<DateTime> DeletedAt { get; set; }

        public BlogCommentsRating BlogCommentsRating { get; set; }
        public User User { get; set; }
    }
}
