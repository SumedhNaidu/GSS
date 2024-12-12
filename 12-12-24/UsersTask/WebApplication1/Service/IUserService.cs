using System.Collections;
using UsersTask.ViewModels;

namespace UsersTask.Service
{
    public interface IUserService
    {
        public string Login(UserLoginDto loginDto);
        public ResponseUserDto Add(CreateUserDto userDto);
        public User GetUserById(int id);
        public void Delete(string user);
        public User GetUserByUsername(string username);
        public IEnumerable<ResponseUserDto> GetAll();
    }
}
