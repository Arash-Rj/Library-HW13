using HW13.Enum;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW13.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime EndDate { get; set; }
        public RoleEnum Role { get; set; }
        public List<BarrowedBook> Books { get; set; }
        public User(string name,string email,string password,RoleEnum role) 
        {
            Name = name;
            Email = email;
            Password = password;
            Role = role;
            if(role == RoleEnum.Member)
            {
                RegisterDate = DateTime.Now;
                EndDate = RegisterDate.AddMonths(1);
            }
            IsActive = true;
        }
        public User() { }
        public override string ToString()
        {
            return $"Id: {Id} | Name: {Name} | Email: {Email} " +
                $"| Password: {Password} | Role: {Role} | Active: {IsUserActive().ToString()} " +
                $"| Subscription Ends in: {EndDate - DateTime.Now}";
        }
        public bool IsUserActive()
        {
            if (Role == RoleEnum.Member)
            { 
            if (DateTime.Now > EndDate)
            { IsActive = false; }
            }
            return IsActive;
        }

    }
}
