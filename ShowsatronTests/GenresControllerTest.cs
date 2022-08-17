using Microsoft.VisualStudio.TestTools.UnitTesting;
using Showsatron.Data;
using Showsatron.Controllers;
using Showsatron.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace ShowsatronTests
{
    [TestClass]
   public class GenresControllerTest
    {
        private ApplicationDbContext _context;
        private GenresController _controller;
        private List<Genre> _genres = new List<Genre>();

        [TestInitialize]
        public void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new ApplicationDbContext(options);
            //mock some data

            //platform
            var platform = new Platform { PlatformId = 1, Name = "Crave" };
            _context.Platforms.Add(platform);
            _context.SaveChanges();

            //list of genres
            var genre1 = new Genre { GenreId = 1, Name = "Drama", Language = "English", Type = "Movie" };
            var genre2 = new Genre { GenreId = 1, Name = "Rom-Com", Language = "Italian", Type = "TV Series" };
            var genre3 = new Genre { GenreId = 1, Name = "Action", Language = "Spanish", Type = "Documentary" };

            _context.Genres.Add(genre1);
            _context.Genres.Add(genre2);
            _context.Genres.Add(genre3);
            _context.SaveChanges();

            _genres.Add(genre1);
            _genres.Add(genre2);
            _genres.Add(genre3);

            //instantiate the controller object
            _controller = new GenresController(_context);
        }


        [TestMethod]
        public void EditReturnsGenreData()
        {
            var result = _controller.Edit(1);
            var viewResult = (ViewResult)result.Result;
            var model = (Genre)viewResult.Model;
            var genre = _genres[0];
            Assert.AreEqual(genre, model);

        }

        [TestMethod]
        public void EditReturnsNotFoundWhenIdIsNull()
        {
            var actionResult = _controller.Edit(null);

            var notFoundResult = (NotFoundResult)actionResult.Result;

            Assert.AreEqual(404, notFoundResult.StatusCode);
        }

        [TestMethod]
        public void EditReturnsNotFoundWhenIdIsNotValid()
        {
            var testId = 86;

            var actionResult = _controller.Edit(testId);

            var notFoundResult = (NotFoundResult)actionResult.Result;

            Assert.AreEqual(404, notFoundResult.StatusCode);
        }
       
    }
}
