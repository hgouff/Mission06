using System.ComponentModel.DataAnnotations;

namespace Mission06.Models;

// class for the movie added
//get/set the variables
//determine if theyre required or if they can be left null
public class Movie
{
    [Required]
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string Category { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public int Year { get; set; }
    [Required]
    public string Director { get; set; }
    [Required]
    public string Rating { get; set; }
    public bool Edited { get; set; }
    public string? LentTo { get; set; }
    
    [StringLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
    public string? Notes { get; set; }
}