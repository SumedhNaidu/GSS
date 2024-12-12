//using System;
//using System.Collections.Generic;
//using System.IdentityModel.Tokens.Jwt;
//using System.Linq;
//using System.Text;
//using Microsoft.IdentityModel.Tokens;
//using UsersTask.ViewModels;

//namespace UsersTask.Service
//{
//    public class UserManager : IUserManager
//    {
//        private readonly List<ResponseUserDto> _users;
//        private readonly string _secretKey = "your_secret_key_here";  // Secret key for JWT generation

//        public UserManager()
//        {
//            // Initialize with some dummy data (optional)
//            _users = new List<ResponseUserDto>
//            {
//                new ResponseUserDto { Username = "admin", Role = "Admin", Email = "admin@example.com", Password = "admin123" },
//                new ResponseUserDto { Username = "user1", Role = "User", Email = "user1@example.com", Password = "user123" }
//            };
//        }

//        public ResponseUserDto Add(CreateUserDto userDto)
//        {
//            if (_users.Any(u => u.Username == userDto.UserName))
//            {
//                throw new InvalidOperationException("User already exists.");
//            }

//            var newUser = new ResponseUserDto
//            {
//                Username = userDto.UserName,
//                Role = userDto.Role,
//                Email = userDto.Email
//            };
//            _users.Add(newUser);
//            return newUser;
//        }

//        public void Delete(string username)
//        {
//            var user = _users.FirstOrDefault(u => u.Username == username);
//            if (user == null)
//            {
//                throw new KeyNotFoundException("User not found.");
//            }
//            _users.Remove(user);
//        }

//        public ResponseUserDto GetUserByUsername(string username)
//        {
//            var user = _users.FirstOrDefault(u => u.Username == username);
//            if (user == null)
//            {
//                throw new KeyNotFoundException("User not found.");
//            }
//            return user;
//        }

//        public IEnumerable<ResponseUserDto> GetAll()
//        {
//            return _users;
//        }

//        // The Login method to verify credentials and generate a JWT token
//        public string Login(UserLoginDto loginDto)
//        {
//            var user = _users.FirstOrDefault(u => u.Username == loginDto.UserName);
//            if (user == null || user.Password != loginDto.Password)
//            {
//                throw new UnauthorizedAccessException("Invalid credentials");
//            }

//            // Generate JWT token
//            var tokenHandler = new JwtSecurityTokenHandler();
//            var key = Encoding.ASCII.GetBytes(_secretKey);

//            var tokenDescriptor = new SecurityTokenDescriptor
//            {
//                Subject = new System.Security.Claims.ClaimsIdentity(new[]
//                {
//                    new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name, user.Username),
//                    new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Role, user.Role)
//                }),
//                Expires = DateTime.UtcNow.AddHours(1),  // Set token expiration time
//                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
//            };

//            var token = tokenHandler.CreateToken(tokenDescriptor);
//            return tokenHandler.WriteToken(token);
//        }
//    }
//}
