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
        return View();
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
        return View();
    }

    
    // Post method for entering movies; sends it to the database
    // Redirect to a confirmation page
    [HttpPost]
    public IActionResult EnterMovies(Movie response)
    {
        // Make sure response is valid
        if (!ModelState.IsValid)
        {
            return View("EnterMovies", response);
        }
        
        //add record to the database
        _context.Movies.Add(response);
        //commit changes
        _context.SaveChanges();
        return View("Confirmation");
    }
}
