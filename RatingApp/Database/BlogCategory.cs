using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RatingApp.Database
{
    public class BlogCategory
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = ("varchar(100)"))]
        [Required]
        public string Title { get; set; }

        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public Nullable<DateTime> UpdatedAt { get; set; }
        public Nullable<DateTime> DeletedAt { get; set; }
    }
}
