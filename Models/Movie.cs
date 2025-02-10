using System.ComponentModel.DataAnnotations;

namespace MissionSix.Models;

public class Movie
{
    [Key]
    public int Id { get; set; }
    
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
    
    [StringLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
    public string? Notes { get; set; }
}