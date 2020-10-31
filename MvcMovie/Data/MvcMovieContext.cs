using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

/**
    This class:
    - connects to the db
    - maps Movie objects to db records

*/

namespace MvcMovie.Data 
{
    public class MvcMovieContext : DbContext
    {
       public MvcMovieContext (DbContextOptions<MvcMovieContext> options)
        :base(options) 
       {

       } 

        //In the entity framework, an entity set typically corresponds to a database table
        //an entity corresponds to a row in the table.
       public DbSet<Movie> Movie {get; set;}
    }
}