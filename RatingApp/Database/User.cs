using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RatingApp.Database
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Guid GUID { get; set; }

        [Column(TypeName = ("varchar(50)"))]
        [Required]
        public string NameSurname { get; set; }

        [Column(TypeName = ("varchar(100)"))]
        [Required]
        public string Email { get; set; }

        [Column(TypeName = ("char(10)"))]
        [Required]
        public string Phone { get; set; }

        [Column(TypeName = ("varchar(50)"))]
        [Required]
        public string Password { get; set; }

        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public Nullable<DateTime> UpdatedAt { get; set; }
        public Nullable<DateTime> DeletedAt { get; set; }
        
    }
}
