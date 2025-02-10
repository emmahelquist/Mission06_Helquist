using System.ComponentModel.DataAnnotations;

namespace MissionSix.Models;

// Class that holds all the variables in the movie form
public class Movie
{
    // Primary key 
    [Key]
    public int Id { get; set; }
    
    // make required and provide error message for the variables needed
    [Required(ErrorMessage = "Please Enter Category")]
    
    public string Category { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Movie Title")]
    public string Title { get; set; }
    
    [Required(ErrorMessage = "Please Enter Movie Year")]
    public int Year { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Movie Director")]
    public string Director { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Movie Rating")]
    public string Rating { get; set; }
    
    public bool Edited { get; set; }
    
    public string? LentTo { get; set; }
    
    // Set character length to 25 
    [StringLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
    public string? Notes { get; set; }
}