using SWMovies.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieReviewRepository
{
    public class ReviewInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ReviewContext>
    {
        protected override void Seed(ReviewContext context)
        {
            var reviews = new List<MovieReview>
            {
            new MovieReview{MovieID=98, Comment="Testowy komentarz", Rating=5, User="Tester"},
            new MovieReview{MovieID=99, Comment="Testowy komentarz2", Rating=10, User="Tester"}
            };

            reviews.ForEach(s => context.Reviews.Add(s));
            context.SaveChanges();
        }
    }
}
