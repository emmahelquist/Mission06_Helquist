using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MissionSix.Models;

// Class that holds all the variables in the movie form
public class Movie
{
    // Primary key 
    [Key]
    [Required]
    [Column("MovieId")]
    public int MovieId { get; set; }
    
    // make required and provide error message for the variables needed
    [Required(ErrorMessage = "Please Enter Category")]
    [ForeignKey("Category")]
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    
    [Required(ErrorMessage = "Please Enter Movie Title")]
    public string Title { get; set; }
    
    // Year needs to be greater than 1888
    [Required, Range(1888, int.MaxValue, ErrorMessage = "Please Enter a Valid Year")]
    public int Year { get; set; }
    
    public string? Director { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Movie Rating")]
    public string Rating { get; set; }
    
    [Required(ErrorMessage = "Please Choose An Option")]
    public bool Edited { get; set; }
    
    public string? LentTo { get; set; }
    
    [Required(ErrorMessage = "Please Choose An Option")]
    public bool CopiedToPlex { get; set; }
    
    // Set character length to 25 
    [StringLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
    public string? Notes { get; set; }
}