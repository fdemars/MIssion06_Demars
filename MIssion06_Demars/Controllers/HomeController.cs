using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Demars.Models;
using MIssion06_Demars.Models;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace MIssion06_Demars.Controllers
{
    public class HomeController : Controller
    {
        private MovieSubmissionContext _context;
        public HomeController(MovieSubmissionContext temp) // Constructor
        {
            _context = temp;
        }
        // link to home page
        public IActionResult Index()
        {
            return View();
        }

        // link to get to know Joel page
        public IActionResult GetToKnowJoel()
        {
            ViewData["Title"] = "Get To Know Joel";
            return View();
        }

        // get the info by going to the page
        [HttpGet]
        public IActionResult EnterNewMovie()
        {
            
            ViewBag.Categories = _context.Categories.ToList(); //put the categories table values in a list stored to a ViewBag

            ViewData["Title"] = "Submit New Movie";
            return View(new Movie());
        }

        // post whatever is submited on the page
        [HttpPost]
        public IActionResult EnterNewMovie(Movie response)
        {
            if (ModelState.IsValid) //check for validation
            {
                _context.Movies.Add(response); //Add record to the database
                _context.SaveChanges();
                ViewData["Title"] = "Success!";

                return View("Confirmation", response);
            }

            else //if the entered info doesn't match requirements for the model, remake the viewbag and go to the EnterMovie view with the response already inputted so they can
                 // just edit what they had already entered
            {
                ViewBag.Categories = _context.Categories.ToList();

                return View(response);
            }
        }

        [HttpGet]
        public IActionResult MovieList()
        {
            //use linq to show records from the database
            var movies = _context.Movies.Include("Category").ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories.ToList(); //put the categories table values in a list stored to a ViewBag

            return View("EnterNewMovie", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Movie updatedInfo)
        {
            if(ModelState.IsValid) // make sure when they update info, they don't take out required info by validating again

            {
                _context.Update(updatedInfo);
                _context.SaveChanges();

                return RedirectToAction("MovieList");
            }
            else
            {
                ViewBag.Categories = _context.Categories.ToList();

                return View("EnterNewMovie", updatedInfo);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movie deletedInfo)
        {
            _context.Movies.Remove(deletedInfo); //delete the record and save the changes to the database
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}
