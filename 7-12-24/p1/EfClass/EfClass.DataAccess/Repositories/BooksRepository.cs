using EfClass.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfClass.DataAccess.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly BookDBContext _context;
        public BooksRepository(BookDBContext context)
        {
            _context = context;
        }
        public bool AddBook(Book book)
        {
            try
            {
                var res =  _context.Books.Add(book);
                if (res != null)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                //log the exception
                return false;
            }
            return false;
        }
        public bool DeleteBook(Book book)
        {
            try
            {
                var res = _context.Remove(book);
                if(res != null)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }

        public IEnumerable<Book> GetAllBooks()
        {
                return _context.Books;
        }

        public Book GetBookDetails(int bookId)
        {
            return _context.Books.FirstOrDefault(x => x.BookId == bookId);
        }

        public bool UpdateBook(Book book)
        {
            var bookDetails = _context.Books.FirstOrDefault(x => x.BookId == book.BookId);
            bookDetails = book;
            _context.SaveChanges();
            return true;
        }
    }
}
