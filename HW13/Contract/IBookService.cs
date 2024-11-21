using HW13.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW13.Contract
{
    public interface IBookService
    {
        Result BarrowBook(int userid,int bookid);
        List<Book> GetLibraryBookList();
        List<BarrowedBook> GetUserBookList(int userid);
        Result ReturnBook(int userid,int bookid);
    }
}
