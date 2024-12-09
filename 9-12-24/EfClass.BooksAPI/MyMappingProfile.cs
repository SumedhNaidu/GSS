using AutoMapper;
using EfClass.Models.DBModels;
using EfClass.Models.DTOs;

namespace EfClass.BooksAPI
{
    public class MyMappingProfile : Profile
    {
        public MyMappingProfile() 
        {
            CreateMap<Book, BookDto>()
                .ForMember(x => x.AuthorName, x => x.MapFrom(y => y.Author.AuthorName))
                .ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
