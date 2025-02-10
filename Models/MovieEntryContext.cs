using Microsoft.EntityFrameworkCore;

namespace MissionSix.Models;

public class MovieEntryContext : DbContext
{
    // Constructor
    public MovieEntryContext(DbContextOptions<MovieEntryContext> options) : base(options)
    {
    }
    
    public DbSet<Movie> Movies { get; set; }
}