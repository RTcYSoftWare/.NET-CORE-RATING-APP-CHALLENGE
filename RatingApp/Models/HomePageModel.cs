using RatingApp.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatingApp.Models
{
    public class HomePageModel
    {
        public List<Blog> Blogs { get; set; }
        public List<Product> Products { get; set; }
    }
}
