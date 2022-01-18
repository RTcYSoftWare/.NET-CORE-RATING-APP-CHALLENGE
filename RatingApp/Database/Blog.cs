using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RatingApp.Database
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = ("varchar(100)"))]
        [Required]
        public string Title { get; set; }

        [Column(TypeName = ("varchar(MAX)"))]
        public string Text { get; set; }

        [Column(TypeName = ("varchar(MAX)"))]
        public string ListImage { get; set; }

        [Column(TypeName = ("varchar(MAX)"))]
        public string BannerImage { get; set; }

        [Required]
        public int BlogCategoryId { get; set; }

        [Required]
        public int Hit { get; set; }

        [Column(TypeName = ("varchar(MAX)"))]
        [Required]
        public string Slug { get; set; }

        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public Nullable<DateTime> UpdatedAt { get; set; }
        public Nullable<DateTime> DeletedAt { get; set; }

        public BlogCategory BlogCategory { get; set; }
        public ICollection<BlogComment> BlogComments { get; set; }
    }
}
