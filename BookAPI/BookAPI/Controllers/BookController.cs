using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookContext _context;

        public BookController(BookContext context)
        {
            _context = context;
        }

        //GET: api/BookDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBookDetails()
        {
            return await _context.Books.ToListAsync();
        }
        // GET: api/BookDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookDetail(int id)
        {
            var bookDetail = await _context.Books.FindAsync(id);

            if (bookDetail == null)
            {
                return NotFound();
            }

            return bookDetail;
        }
        // PUT: api/BookDetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookDetail(int id, Book bookDetail)
        {
            if (id != bookDetail.BookId)
            {
                return BadRequest();
            }

            _context.Entry(bookDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookDetailExists(id))
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
        // POST: api/BookDetail
        [HttpPost]
        public async Task<ActionResult<Book>> PostBookDetail(Book bookDetail)
        {
            _context.Books.Add(bookDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookDetail", new { id = bookDetail.BookId }, bookDetail);
        }
        //// DELETE: api/BookDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookDetail(int id)
        {
            var bookDetail = await _context.Books.FindAsync(id);
            if (bookDetail == null)
            {
                return NotFound();
            }

            _context.Books.Remove(bookDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool BookDetailExists(int id)
        {
            return _context.Books.Any(e => e.BookId == id);
        }

    }
}
