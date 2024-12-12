using AutoMapper;
using DocumentFormat.OpenXml.Spreadsheet;
using UsersTask.ViewModels;

namespace UsersTask.Mappers
{
    public class CreateUserMapper:Profile
    {
        public CreateUserMapper()
        {
            CreateMap<Users, CreateUserDto>();
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<ResponseUserDto, CreateUserDto>().ReverseMap();
            CreateMap<User, ResponseUserDto>();
        }
    }
}
