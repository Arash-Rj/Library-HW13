using HW13.Entities;
using HW13.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HW13.Configuration
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Password).HasMaxLength(128);
            builder.Property(x=>x.Email).HasMaxLength(64);
            builder.Property(x => x.Name).HasColumnName("FirstName").HasMaxLength(128);
            builder.Property(x => x.Role).HasColumnName("RoleNumber");
            builder.HasData
                (
                new User { Id = 1, Name = "Arash", Email = "rajabiarash36@gmail.com", Password = "12345", Role = RoleEnum.Librarian }
                //new User { Id = 2, Name = "Ali", Email = "Ali@gmail.com", Password = "1234", Role = RoleEnum.Member , RegisterDate=DateTime.Now , EndDate=DateTime.Now.AddMonths(1) },
                //new User { Id = 3, Name = "mahdi", Email = "mahdi@gmail.com", Password = "123", Role = RoleEnum.Member , RegisterDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(1) },
                //new User {Id = 4, Name = "ashkan", Email = "ashkan@gmail.com", Password = "12", Role = RoleEnum.Member, RegisterDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(1) }
                );

        }
    }
}
