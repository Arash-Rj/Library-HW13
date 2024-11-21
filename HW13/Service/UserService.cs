using HW13.Contract;
using HW13.DataBase;
using HW13.Entities;
using HW13.Enum;
using HW13.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HW13.Service
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository = new UserRepository();

        public Result changeSubscriptinoDate(int userid, string subscriptinoDate)
        {
            var date = DateTime.Now;
            bool isparsed = DateTime.TryParse(subscriptinoDate, out date);
            var isvalid = _userRepository.IsUserIdValid(userid);
            if (!isparsed)
            {
                return new Result(false, "Invalid date format.please try again.");
            }
            if(!isvalid)
            {
                return new Result(false, "The user could not be found please enter the correct id.");
            }
            var isupdated = _userRepository.UpdateUserDate(userid, date);
            if(isupdated)
            {
                return new Result(true, "User Seccessfully updated.");
            }
            return new Result(false, "Could not update user.");
        }

        public List<User>? GetAllUsers()
        {
           return _userRepository.GetAllUser();
        }

        public bool IsUserAdmin(int userId)
        {
           return _userRepository.IsAdmin(userId);
        }

        public Result Login(string email, string password)
        {
           bool exist =  _userRepository.DoesUserExist(email, password);
            if (exist)
            {
                var user = _userRepository.GetUserByEmail(email);
                if(!user.IsUserActive())
                {
                    return new Result(false, "User is not Active, please activate user first.");
                }
                OnlineUser.user = user;
                return new Result(true, "User Logged in successfully.");
            }
            return new Result(false, "User was not found please try again.");
        }

        public Result Logout()
        {
            OnlineUser.user = null;
            return new Result(true);
        }

        public Result Register(string name, string email, string password, RoleEnum role)
        {
            if (name == "" || email == "" || password == "")
            {
                return new Result(false, "Feilds can not be empty. try again.");
            }
            if(_userRepository.DoesUserExist(email,password))
            {
                return new Result(false, "The User Already exists.");
            }
            if(_userRepository.AddUser(name, email, password,role))
            {
                return new Result(true,"User Registered successfully.");
            }
            return new Result(false,"User could not be registered.");
        }
    }
}
