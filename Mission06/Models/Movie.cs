using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Mission06.Models;

// class for the movie added
//get/set the variables
//determine if they're required or if they can be left null
public class Movie
{
    [Required]
    [Key]
    public int MovieId { get; set; }
    
    [Required]
    [ForeignKey("CategoryId")]
    public int CategoryId { get; set; }
    public Category CategoryName { get; set; }
    
    [Required]
    public string Title { get; set; }
    [Required]
    public int Year { get; set; }
    [Required]
    public string Director { get; set; }
    [Required]
    public string Rating { get; set; }
    public bool? Edited { get; set; }
    public string? LentTo { get; set; }
    
    [Required]
    public bool CopiedToPlex { get; set; }
    
    [StringLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
    public string? Notes { get; set; }
}