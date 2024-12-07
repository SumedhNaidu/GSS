using EfClass.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfClass.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        public readonly BookDBContext _context;
        public bool AddUser(User user)
        {
            try
            {
                var res = _context.Users.Add(user);
                if (res != null)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }

        public bool DeleteUser(User user)
        {
            try
            {
                var res = _context.Users.Remove(user);
                if (res != null)
                {
                    return true;
                }
            }
            catch (Exception ex) {
                return false;
            }
            return false;
        }

        public IEnumerable<User> GetAllUsers()
        {
            try
            {
                return _context.Users.ToList();
            }
            catch (Exception ex) {
                return Enumerable.Empty<User>();
            }
        }

        public User GetUserDetails(int Id)
        {
            try
            {
                var res = _context.Users.Find(Id);
                if (res != null)
                {
                    return res;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }

        public bool UpdateUser(User user)
        {
            try
            {
                _context.Users.Update(user);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
