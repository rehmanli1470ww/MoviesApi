using Microsoft.EntityFrameworkCore;
using MoviesApi.Entities;

namespace MoviesApi.Data
{
    public class MoviesDbContext:DbContext
    {
        public MoviesDbContext(DbContextOptions<MoviesDbContext> options) 
            : base(options)
        {
            
        }
        public DbSet<Movie> Movies { get; set; }
    }
}
