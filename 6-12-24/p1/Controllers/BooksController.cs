using AutoMapper;
using BookStore_Many_to_Many.Database;
using BookStore_Many_to_Many.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookStore_Many_to_Many.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BookDBContext _context;
        public readonly IMapper _mapper;
        public BooksController(BookDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //GET: api/Books
        [HttpGet]
        public IActionResult Get()
        {
            List<BookDto> bookDtos = new List<BookDto>();
            var books = _context.Books.Include(x => x.Author).ToList();
            _mapper.Map(books, bookDtos);
        /*    foreach(var book in books)
            {
                bookDtos.Add(new BookDto
                {
                    BookId = book.BookId,
                    Title = book.Title,
                    AuthorName = book.Author.AuthorName
                });
            }*/

            return Ok(bookDtos);
        }
        //POST: api/Books
        [HttpPost]
        public IActionResult Post([FromBody] BookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            _context.Books.Add(book);
            _context.SaveChanges();
            return Ok();
        }


        //PUT

        //DELETE

    }
}
