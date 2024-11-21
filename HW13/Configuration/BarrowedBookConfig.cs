using HW13.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW13.Configuration
{
    public class BarrowedBookConfig : IEntityTypeConfiguration<BarrowedBook>
    {
        public void Configure(EntityTypeBuilder<BarrowedBook> builder)
        {
            builder.HasKey( b => b.Number);
            builder.HasOne(b => b.User).WithMany(u => u.Books).HasForeignKey(b => b.UserId);
            builder.HasOne(b => b.Book).WithOne(b => b.books).HasForeignKey<BarrowedBook>(b => b.BookId);
        }
    }
}
