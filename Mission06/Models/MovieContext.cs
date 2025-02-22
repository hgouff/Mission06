using Microsoft.EntityFrameworkCore;
namespace Mission06.Models;


public class MovieContext:DbContext
{
    public MovieContext(DbContextOptions<MovieContext> options): base(options)//contructor
    {
    
    }

    public DbSet<Movie> Movies { get; set; }
}
