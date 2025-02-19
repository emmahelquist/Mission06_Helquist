using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

    [HttpGet]
    public IActionResult ViewList()
    {
        var movies = _context.Movies
            .Include(x => x.Category)
            .ToList();
        
        return View(movies);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var movieToEdit = _context.Movies
            .Include(x => x.Category)
            .Single(x => x.MovieId == id);
        // Pull record
        ViewBag.Categories = _context.Categories.ToList();
        return View("EnterMovies", movieToEdit );
    }

    [HttpPost]
    public IActionResult Edit(Movie updatedInfo)
    {
        _context.Update(updatedInfo);
        _context.SaveChanges();
        
        return RedirectToAction("ViewList");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var recordToDelete = _context.Movies
            .Single(x => x.MovieId == id);
        
        return View(recordToDelete);
    }

    [HttpPost]
    public IActionResult Delete(Movie recordToDelete)
    {
        _context.Movies.Remove(recordToDelete);
        _context.SaveChanges();
        return RedirectToAction("ViewList");
    }
}
