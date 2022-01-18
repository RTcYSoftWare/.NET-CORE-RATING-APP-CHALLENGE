using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatingApp.Database
{
    public class RatingAppDBContext : DbContext
    {
        public RatingAppDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<BlogComment> BlogComments { get; set; }
        public DbSet<BlogCommentsRating> BlogCommentsRatings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductsRating> ProductsRatings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>().ToTable("Blogs");
            modelBuilder.Entity<BlogCategory>().ToTable("BlogCategories");
            modelBuilder.Entity<BlogComment>().ToTable("BlogComments");
            modelBuilder.Entity<BlogCommentsRating>().ToTable("BlogCommentsRatings");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<ProductsRating>().ToTable("ProductsRatings");
        }

    }
}



//public BlogCategory BlogCategory { get; set; }
//public ICollection<BlogTag> BlogTags { get; set; }
//public ICollection<BlogVideo> BlogVideos { get; set; }
//public ICollection<BlogImage> BlogImages { get; set; }
//public ICollection<BlogComment> BlogComments { get; set; }

//public User User { get; set; }