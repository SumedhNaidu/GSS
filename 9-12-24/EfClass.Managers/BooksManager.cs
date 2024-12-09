using AutoMapper;
using EfClass.DataAccess.Repositories;
using EfClass.Models.DBModels;
using EfClass.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfClass.Managers
{
    public class BooksManager : IBooksManager
    {
        private readonly IMapper _mapper;
        private readonly IBooksRepository _booksRepository;

        public BooksManager(IMapper mapper, IBooksRepository booksRepository)
        {
            _mapper =mapper;
            _booksRepository = booksRepository;
        }

        /// <see cref="IBooksManager.AddNewBook(BookDto)"/>
        public bool AddNewBook(BookDto book)
        {
           Book dbBook = _mapper.Map<Book>(book);
            return _booksRepository.AddBook(dbBook);
        }

        ///<see cref="IBooksManager.GetAllBooks()"/>
        public IEnumerable<BookDto> GetAllBooks()
        {
            var books = _booksRepository.GetAllBooks();
            var booksList = _mapper.Map<List<BookDto>>(books);
            return booksList;
        }

        public BookDto GetBookDetails(int bookId)
        {
            var book = _booksRepository.GetBookDetails(bookId);
            return _mapper.Map<BookDto>(book);
        }

        public bool RemoveBook(int bookId)
        {
            return _booksRepository.DeleteBook(bookId);
        }

        public bool UpdateBook(BookDto book)
        {
            var dbBook = _mapper.Map<Book>(book);
            return _booksRepository.UpdateBook(dbBook);
        }
    }
}
