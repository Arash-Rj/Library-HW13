using HW13.Contract;
using HW13.DataBase;
using HW13.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW13.Repository
{
    public class BookRepository : IBookRepository
    {
        private HW13DbContext HW13DbContext = new HW13DbContext();
        public bool Barrow(BarrowedBook book)
        {
            HW13DbContext.BarrowedBooks.Add(book);
            HW13DbContext.SaveChanges();
            return true;
        }

        public Book? GetBookById(int bookId)
        {
            return HW13DbContext.Books.SingleOrDefault(b => b.Id == bookId);
        }

        public List<Book>? GetLibraryBooks()
        {
            return HW13DbContext.Books.AsNoTracking().ToList();
        }

        public BarrowedBook? GetUserBarrowedBId(int userid, int bookid)
        {
            return HW13DbContext.BarrowedBooks
                .AsNoTracking()
                .SingleOrDefault(b => b.BookId.Equals(bookid) && b.UserId.Equals(userid));
        }

        public List<BarrowedBook>? GetUserBooks(int userId)
        {
            return HW13DbContext.BarrowedBooks.AsNoTracking()
                .Where(b => b.UserId == userId)
                .ToList();
        }

        public bool IsBarrowedBefore(int bookId)
        {
           return HW13DbContext.BarrowedBooks.Any(b=>b.BookId == bookId);
        }

        public bool Return(BarrowedBook barrowedBook)
        {
            HW13DbContext.BarrowedBooks.Remove(barrowedBook);
            HW13DbContext.SaveChanges();
            return true;
        }
    }
}
