using EfClass.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfClass.DataAccess.Repositories
{
    public interface IUserRepository
    {
        /// <summary>
        /// add user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool AddUser(User user);
        /// <summary>
        /// update user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool UpdateUser(User user);
        /// <summary>
        /// delete user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool DeleteUser(User user);
        /// <summary>
        /// get all users
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> GetAllUsers();
        /// <summary>
        /// get user details by id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public User GetUserDetails(int Id);
    }
}
