using EfClass.Managers;
using EfClass.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfClass.Services
{
    public class BookService : IBookService
    {
        private readonly IBooksManager _bookManager;
        //logger
        public BookService(IBooksManager bookManager)
        {
            _bookManager = bookManager;
        }
        public bool AddNewBook(BookDto book)
        {
            return _bookManager.AddNewBook(book);
        }

        public IEnumerable<BookDto> GetAllBooks()
        {
            return _bookManager.GetAllBooks();
        }

        public BookDto GetBookDetails(int bookId)
        {
            return _bookManager.GetBookDetails(bookId);
        }

        public bool RemoveBook(int bookId)
        {
            return _bookManager.RemoveBook(bookId);
        }

        public bool UpdateBook(BookDto book)
        {
            return _bookManager.UpdateBook(book);
        }
    }
}
