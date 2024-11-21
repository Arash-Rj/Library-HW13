using HW13.Contract;
using HW13.DataBase;
using HW13.Entities;
using HW13.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW13.Repository
{
    public class UserRepository : IUserRepository
    {
        private HW13DbContext HW13DbContext  = new HW13DbContext();
        public bool AddUser(string name, string eamil, string password,RoleEnum role)
        {
            var user = new User(name, eamil, password, role);
            try
            {
                HW13DbContext.Users.Add(user);
                HW13DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool DoesUserExist(string eamil, string password)
        {
            return HW13DbContext.Users.Any(u => u.Email == eamil && u.Password == password);
        }

        public List<User>? GetAllUser()
        {
            return HW13DbContext.Users.AsNoTracking().ToList();
        }

        public User GetUserByEmail(string email)
        {
            return HW13DbContext.Users.AsNoTracking().Single(u => u.Email == email);
        }

        public bool IsAdmin(int userid)
        {
            return HW13DbContext.Users.Where(u => u.Id.Equals(userid)).Any(u => u.Role==RoleEnum.Librarian);
        }

        public bool IsUserIdValid(int userid)
        {
            return HW13DbContext.Users.Any(u => u.Id == userid);
        }

        public bool UpdateUserDate(int userid, DateTime EndDate)
        {
           var user = HW13DbContext.Users.FirstOrDefault(u => u.Id == userid);
            if(user is null || user.IsActive==true)
            {
                return false;
            }
            user.EndDate = EndDate;
            HW13DbContext.SaveChanges();
            return true;
        }
    }
}
