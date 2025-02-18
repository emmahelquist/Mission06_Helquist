using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MissionSix.Models;
using SQLitePCL;

namespace MissionSix.Controllers;

public class HomeController : Controller
{
    
    // Private variable with bigger scope 
    private MovieEntryContext _context;
    
    // Constructor
    public HomeController(MovieEntryContext temp)
    {
        _context = temp;
    }
    
    // Homepage route
    public IActionResult Index()
    {
        if (_context.Categories == null)
        {
            return NotFound("Database connection failed or Categories table is missing.");
        }

        var categories = _context.Categories.ToList();
        return View(categories);
    }

    // Get to know joel route
    public IActionResult GetToKnowJoel()
    {
        return View();
    }

    
    // Get method for entering movies; renders page
    [HttpGet]
    public IActionResult EnterMovies()
    {
        ViewBag.Categories = _context.Categories.ToList();
        return View();
    }
    
    // Post method for entering movies; sends it to the database
    // Redirect to a confirmation page
    [HttpPost]
    public IActionResult EnterMovies(Movie response)
    {
        
        //add record to the database
        _context.Movies.Add(response);
        //commit changes
        _context.SaveChanges();
        return View("Confirmation", response);
    }
}
