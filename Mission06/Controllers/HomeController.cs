using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06.Models;

namespace Mission06.Controllers;

public class HomeController : Controller
{
    private MovieContext _context;
    
    public HomeController(MovieContext someName) //constructor
    {
        _context = someName;
        _context.SaveChanges(); // Save changes to the database
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GetToKnowJoel()
    {
        return View();
    }
// get data from the MovieCollection inputs
    [HttpGet]
    public IActionResult MovieCollection()
    {
        return View("MovieCollection");
    }
//post data from the inputs into the database
    [HttpPost]
    public IActionResult MovieCollection(Movie response)
    {
        if (!ModelState.IsValid)
        {
            return View(response); // Return the form with validation errors
        }
        
        _context.Movies.Add(response); //add record to database 
        _context.SaveChanges();
        
        return View("Confirmation", response);
    }

}

    