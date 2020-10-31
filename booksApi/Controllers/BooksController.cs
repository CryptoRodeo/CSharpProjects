//All these dependencies are automatically injected into the code via the commands
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using booksApi.Models;

namespace booksApi.Controllers
{
    [Route("api/[controller]")]
    //This attribute indicates that the controller responds to web api requests.
    [ApiController]
    public class BooksController : ControllerBase
    {
        //The database context was also injected into the controller via DI
        private readonly BookContext _context;
        //The DB is used in each of the CRUD methods in the controller.
        public BooksController(BookContext context)
        {
            _context = context;
        }

        // GET: api/Books
        [HttpGet]

        /**
            The return types for the get controllers is ActionResult<T>

            This return type returns:
            - An HTTP status code
            - The object serialized into JSON and then written into the body of the response
        */ 
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(long id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]

        //IActionResult is used when multiple ActionResult return types are possible in an action
        public async Task<IActionResult> PutBook(long id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Books
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync(); //saves changes to the db

            /**
                returns 201 if successful

                adds a location header to the response

                the location header speicifies the uri of the newly created todo item

                references GetBook action to create the location headers URI

                the nameof keyword is used to avoid hardcoding the action name in the CreatedAtAction call

                //CreatedAtAction takes a String, Object, Object in its parameter

                //The string is the action's name for generating the URL

                //The object is the route data used for generating the URL, in this case its an object that holds the
                id of the book

                //the last object is the value to format the entities body, in this case the entity we want
                to format the content value to is book.
            */
            return CreatedAtAction(nameof(GetBook), new { id = book.Id}, book);
//            return CreatedAtAction("GetBook", new { id = book.Id }, book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> DeleteBook(long id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return book;
        }

        private bool BookExists(long id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
