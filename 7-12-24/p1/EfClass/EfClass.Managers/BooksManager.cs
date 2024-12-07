using AutoMapper;
using EfClass.DataAccess.Repositories;
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

        public BooksManager(IMapper mapper)
        {
            _mapper =mapper;
        }

        public bool AddNewBook(BookDto book)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookDto> GetAllBooks()
        {
            throw new NotImplementedException();
        }

        public BookDto GetBookDetails(int bookId)
        {
            throw new NotImplementedException();
        }

        public bool RemoveBook(int bookId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateBook(BookDto book)
        {
            throw new NotImplementedException();
        }
    }
}
