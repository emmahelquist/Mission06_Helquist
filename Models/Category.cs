using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MissionSix.Models;

//Class that links the category ID to the name
public class Category
{
    [Key]
    [Column("CategoryId")]  // Matches the database
    public int CategoryId { get; set; }

    public string CategoryName { get; set; }

    public List<Movie>? Movies { get; set; }  // ✅ One-to-Many Relationship
}
