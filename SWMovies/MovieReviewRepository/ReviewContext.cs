using Microsoft.EntityFrameworkCore;
using SWMovies.Models;

namespace MovieReviewRepository
{
    public class ReviewContext : DbContext
    {
        public ReviewContext() : base()
        {
        }

        public ReviewContext(DbContextOptions<ReviewContext> options) : base(options)
        {
        }

        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>().ToTable("Review");
            //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}
