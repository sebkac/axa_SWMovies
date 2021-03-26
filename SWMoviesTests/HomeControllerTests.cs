using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieReviewRepository;
using SWapiRepository;
using SWMovies.Controllers;
using SWMovies.Models;
using System.Collections.Generic;

namespace SWMoviesTests
{
    [TestClass]
    public class HomeControllerTest
    {
        Mock<ILogger<HomeController>> mockLogger;
        Mock<ReviewContext> mockContext;
        Mock<IRepository<Film>> mockFilmRepo;

        [TestInitialize]
        public void Setup()
        {
            mockLogger = new Mock<ILogger<HomeController>>();
            mockContext = new Mock<ReviewContext>();
            mockFilmRepo = new Mock<IRepository<Film>>();
            var fakeFilms = new List<Film>()
                { new Film(){EpisodeId="56", Title="Another Death Star" },
                  new Film(){EpisodeId="456", Title="Wake up Joda" }
                  };
            mockFilmRepo.Setup(f => f.GetEntities(It.IsAny<int>(), It.IsAny<int>())).Returns(fakeFilms);

        }

        [TestMethod]
        public void MoviesViewTest()
        {
            
            var controller = new HomeController(mockLogger.Object, mockContext.Object, mockFilmRepo.Object);
            var result = controller.Index() as ViewResult;
            Assert.AreEqual(2, ((List<Movie>)result.Model).Count);
        }

        [TestMethod]
        public void DetailsTest()
        {

            var controller = new HomeController(mockLogger.Object, mockContext.Object, mockFilmRepo.Object);
            var result = controller.Details(56) as ViewResult;
            Assert.AreEqual("Wake up Joda", ((Movie)result.Model).Title);
        }
    }
}
