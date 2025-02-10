using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MissionSix.Models;
using SQLitePCL;

namespace MissionSix.Controllers;

public class HomeController : Controller
{
    
    // Private variable with bigger scope 
    private MovieEntryContext _context;

    public HomeController(MovieEntryContext temp)
    {
        _context = temp;
    }
    
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GetToKnowJoel()
    {
        return View();
    }

    [HttpGet]
    public IActionResult EnterMovies()
    {
        return View();
    }

    [HttpPost]
    public IActionResult EnterMovies(Movie response)
    {
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
