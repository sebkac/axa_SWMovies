using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieReviewRepository;
using SWapiRepository;
using SWMovies.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SWMovies.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ReviewContext _context;
        private static IRepository<Film> _filmsRepo;

        public HomeController(ILogger<HomeController> logger, ReviewContext context, IRepository<Film> filmsRepo)
        {
            _logger = logger;
            _context = context;
            _filmsRepo = filmsRepo;
        }

        public IActionResult Index()
        {
            var movies = new List<Movie>();
            var films = _filmsRepo.GetEntities(size: int.MaxValue);
            if (films == null)
            {
                _logger.LogError("No films!");
                return View();
            }

            foreach (var film in films)
            {
                movies.Add(new Movie()
                {
                    ID = int.Parse(film.EpisodeId),
                    Title = film.Title,
                    Director = film.Director,
                    ReleaseDate = film.ReleaseDate,
                });
                
            }
            return View(movies);
        }

        
        public IActionResult Details(int? id)
        {
            var reviews = _context.Reviews.Where(r => r.MovieID == id.ToString()).ToList();
            var films = _filmsRepo.GetEntities(size: int.MaxValue);
            var film = films.Where(f=>f.EpisodeId == id.ToString()).FirstOrDefault();
            var movie = new Movie()
            {
                ID = int.Parse(film.EpisodeId),
                Title = film.Title,
                Director = film.Director,
                ReleaseDate = film.ReleaseDate,
                Reviews= reviews,
            };
            TempData["EpisodeId"] = film.EpisodeId;
                       

            return View(movie);
        }
        
        public IActionResult AddReview()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddReview([Bind("Comment,Rating,User")] Review review)
        {
            var EpisodeId = (string)TempData["EpisodeId"];
            var newReview = new Review()
            {
                Comment = review.Comment,
                Rating = review.Rating,
                MovieID = EpisodeId,
                User = review.User,
            };
            _context.Reviews.Add(newReview);
            _context.SaveChanges();
                        
            return RedirectToAction("Details", new { id = int.Parse(EpisodeId) });
        }
               
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
