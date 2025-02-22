using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Mission06.Models;

// class for the movie added
//get/set the variables
//determine if they're required or if they can be left null
public class Movie
{
    [Key]
    public int MovieId { get; set; }
    
    [Required]
    public int CategoryId { get; set; } // Keep the FK as an int
    
    [ForeignKey("CategoryId")]
    public Category? Category { get; set; } // This is the navigation property
    
    [Required]
    public string? Title { get; set; } 
    
    [Required]
    public string? Year { get; set; } 
    
    [Required]
    public string? Director { get; set; } 
    
    [Required]
    public string? Rating { get; set; } 
    
    [Column(TypeName = "INTEGER")]
    public bool Edited { get; set; }
    public string? LentTo { get; set; }
    
    [Required]
    [Column(TypeName = "INTEGER")]
    public bool CopiedToPlex { get; set; }
    
    [StringLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
    public string? Notes { get; set; }
}