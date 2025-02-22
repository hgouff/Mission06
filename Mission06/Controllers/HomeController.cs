using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
       ViewBag.Categories = _context.Categories
           .OrderBy(x=> x.CategoryName).ToList();
       
        return View("MovieCollection", new Movie());
    }
//post data from the inputs into the database
    [HttpPost]
    public IActionResult MovieCollection(Movie response)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Add(response); //add record to database 
            _context.SaveChanges();
            return View("Confirmation", response);
        }
        else
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x=> x.CategoryName).ToList();
            return View(response); // Return the form with validation errors
        }
        
       
    }

    
    public IActionResult MovieList()
    {
        var movies = _context.Movies
            // .Where(x => x.Year >= 1888)
            .OrderBy(x => x.Title)
            .Select(x => new Movie
            {
                Title = x.Title ?? "Unknown Title",  // Handle NULL title
                // CategoryName= x.CategorId ?? "Unknown Category",  // Handle NULL genre
                Director = x.Director ?? "Unknown Director", // Handle NULL director
                
            })
            .ToList();

        return View(movies);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var recordToEdit = _context.Movies
            .SingleOrDefault(x => x.MovieId == id);
        ViewBag.Categories = _context.Categories
            .OrderBy(x=> x.CategoryName).ToList();

        return View("MovieCollection", recordToEdit);
    }

    [HttpPost]
    public IActionResult Edit(Movie updatedInfo)
    {
        _context.Update(updatedInfo);
        _context.SaveChanges();
        return RedirectToAction("MovieList");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var recordToDelete = _context.Movies
            .SingleOrDefault(x => x.MovieId == id);
        return View(recordToDelete);
    }

    [HttpPost]

    public IActionResult Delete(Movie updatedInfo)
    {
        _context.Movies.Remove(updatedInfo);
        _context.SaveChanges();
        return RedirectToAction("MovieList");
    }

}

    