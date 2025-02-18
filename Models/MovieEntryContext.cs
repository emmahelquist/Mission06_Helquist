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
    public DbSet<Category> Categories { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // This links CategoryId to the different names of the categories
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, CategoryName = "Miscellaneous" },
            new Category { CategoryId = 2, CategoryName = "Drama" },
            new Category { CategoryId = 3, CategoryName = "Television" },
            new Category { CategoryId = 4, CategoryName = "Horror/Suspense" },
            new Category { CategoryId = 5, CategoryName = "Comedy" },
            new Category { CategoryId = 6, CategoryName = "Family" },
            new Category { CategoryId = 7, CategoryName = "Action/Adventure" },
            new Category { CategoryId = 8, CategoryName = "VHS" }
        );
    }
}