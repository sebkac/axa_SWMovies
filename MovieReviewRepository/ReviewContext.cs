using SWMovies.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Text;

namespace MovieReviewRepository
{
    public class ReviewContext : DbContext
    {

        public ReviewContext() : base("ReviewContext")
        {
        }

        public DbSet<MovieReview> Reviews { get; set; }
       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
