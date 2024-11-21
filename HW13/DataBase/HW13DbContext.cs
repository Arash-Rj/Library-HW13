using HW13.Configuration;
using HW13.Entities;
using HW13.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW13.DataBase
{
    public class HW13DbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbConfig.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new BarrowedBookConfig());
            modelBuilder.Entity<Book>().HasData
                (
                new Book { Id = 1 , Author = "A" , Title = "C#" , Genre = GenreEnum.Programming , Status=StatusEnum.NotBarrowed },
                new Book { Id = 2, Author = "B", Title = "sql", Genre = GenreEnum.Programming, Status = StatusEnum.NotBarrowed },
                new Book { Id = 3, Author = "C", Title = "Math", Genre = GenreEnum.Engineering, Status = StatusEnum.NotBarrowed }
                );               
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<BarrowedBook> BarrowedBooks { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
