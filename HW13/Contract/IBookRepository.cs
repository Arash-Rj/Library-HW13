using HW13.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace HW13.Contract
{
    public interface IBookRepository
    {
        bool Barrow(BarrowedBook book);
        List<BarrowedBook>? GetUserBooks(int userId);
        List<Book>? GetLibraryBooks();
        bool Return(BarrowedBook barrowedBook);
        Book? GetBookById(int bookId);
        BarrowedBook? GetUserBarrowedBId(int userid, int bookid);
        bool IsBarrowedBefore(int bookId);
    }
}
