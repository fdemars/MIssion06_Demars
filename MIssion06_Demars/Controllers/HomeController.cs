using Microsoft.AspNetCore.Mvc;
using Mission06_Demars.Models;
using MIssion06_Demars.Models;
using System.Diagnostics;

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
            ViewData["Title"] = "Submit New Movie";
            return View();
        }

        // post whatever is submited on the page
        [HttpPost]
        public IActionResult EnterNewMovie(Movie response)
        {
            _context.Movies.Add(response); //Add record to the database
            _context.SaveChanges();
            ViewData["Title"] = "Success!";
            return View("Confirmation");
        }
    }
}
