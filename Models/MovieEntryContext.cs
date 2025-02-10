using Microsoft.EntityFrameworkCore;

namespace MissionSix.Models;

// Inherits from the DbContext
public class MovieEntryContext : DbContext
{
    // Constructor
    public MovieEntryContext(DbContextOptions<MovieEntryContext> options) : base(options)
    {
    }
    
    // Name the database table by creating an instance of the class
    public DbSet<Movie> Movies { get; set; }
}