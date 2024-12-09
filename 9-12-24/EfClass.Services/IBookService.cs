using EfClass.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfClass.Services
{
    public interface IBookService
    {
        /// <summary>
        /// Add a new book
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public bool AddNewBook(BookDto book);
        /// <summary>
        /// Remove book based on id
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns>true/false</returns>
        public bool RemoveBook(int bookId);
        /// <summary>
        /// Get all books in DB
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BookDto> GetAllBooks();
        /// <summary>
        /// get book details based on id
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public BookDto GetBookDetails(int bookId);
        /// <summary>
        /// updates book
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public bool UpdateBook(BookDto book);

    }
}
