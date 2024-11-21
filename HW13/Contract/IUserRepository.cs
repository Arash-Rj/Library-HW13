using HW13.Entities;
using HW13.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW13.Contract
{
    public interface IUserRepository
    {
        bool AddUser(string name,string eamil,string password,RoleEnum role);
        bool DoesUserExist(string eamil,string password);
        List<User>? GetAllUser();
        User GetUserByEmail(string email);
        bool IsUserIdValid(int userid);
        bool IsAdmin(int userid);
        bool UpdateUserDate(int userid, DateTime EndDate);
    }
}
