using AutoMapper;
using BookStore_Many_to_Many.Database;
using BookStore_Many_to_Many.ViewModel;
using BookStore_Many_to_Many.Viewmodels;

namespace BookStore_Many_to_Many
{
    public class MyMappingProfile : Profile
    {
        public MyMappingProfile() 
        {
            //DB to VM
            //Forward Mapping
            //CreateMap<Database.Book, ViewModel.BookDto>();

            //VM to DB
            //Backward Mapping
            CreateMap<Book, BookDto>()
                .ForMember(x => x.AuthorName,x => x.MapFrom(y => y.Author.AuthorName))
                .ReverseMap();
            //or
            //CreateMap<ViewModel.BookDto, Database.Book>();

             CreateMap<Author,AuthorDto>().ReverseMap();
            CreateMap<Category,CategoryDto>().ReverseMap();
        }
    }
}
