using HW13.Entities;
using HW13.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW13.Contract
{
    public interface IUserService
    {
        public Result Login(string email, string password);
        public Result Register(string name,string email,string password,RoleEnum role);
        public Result Logout();
        public List<User>? GetAllUsers();
        public bool IsUserAdmin(int userId);
        public Result changeSubscriptinoDate(int userid,string subscriptinoDate);
    }
}
