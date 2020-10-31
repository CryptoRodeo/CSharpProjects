using Microsoft.EntityFrameworkCore; //the ORM

namespace booksApi.Models
{
    //This context is the main class that coordinates with the Entity framework ORM
    //It interacts with the data as objects.
    public class BookContext : DbContext
    {

        public BookContext(DbContextOptions<BookContext> options)
        :base(options)
        {

        }

        //DbSet represents the collection of the specified entities in the context
        //in this case, the entity is book and the collection is books
        public DbSet<Book> Books {get; set;}
    }
}