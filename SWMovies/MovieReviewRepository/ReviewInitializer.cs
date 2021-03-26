using SWMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieReviewRepository
{
    public static class ReviewInitializer 
    {
        public static void Initialize(ReviewContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            if (context.Reviews.Any())
            {
                var reviewss = context.Reviews.ToList();
                return;   
            }
            var reviews = new List<Review>
            {
            new Review{MovieID="2", Comment="Może być", Rating=5, User="Tester"},
            new Review{MovieID="5", Comment="Najlepszy SW", Rating=10, User="Tester"}
            };

            reviews.ForEach(s => context.Reviews.Add(s));
            context.SaveChanges();
        }
    }
}
