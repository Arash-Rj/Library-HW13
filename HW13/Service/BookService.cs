using HW13.Contract;
using HW13.Entities;
using HW13.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW13.Service
{
    public class BookService : IBookService
    {
        IBookRepository _bookRepository = new BookRepository();
        IUserRepository _userRepository = new UserRepository();
        public Result BarrowBook(int userid, int bookid)
        {
            bool isvalid = _userRepository.IsUserIdValid(userid);
            var book = _bookRepository.GetBookById(bookid);
            if(isvalid && book is not null)
            {
                if(_bookRepository.IsBarrowedBefore(bookid))
                {
                    return new Result(false, "This book is already barrowed.");
                }
                var BarrowBook = new BarrowedBook(book, userid);
                _bookRepository.Barrow(BarrowBook);
                return new Result(true, "Book is succesfully barrowed.");
            }
            if(book is null)
            {
                return new Result(false, "Book was not found, The BookId was wrong, try again.");
            }
            if(!isvalid)
            {
                return new Result(false, "The user could not be found please enter the correct id.");
            }
            return new Result(false, "Could not barrow book.");
        }

        public List<Book>? GetLibraryBookList()
        {
            var books = _bookRepository.GetLibraryBooks();
            return books;
        }

        public List<BarrowedBook>? GetUserBookList(int userid)
        {
            var isvalid = _userRepository.IsUserIdValid(userid);
            if (!isvalid)
            {
                throw new NullReferenceException("User is not valid, id is wrong.");
            }
            return _bookRepository.GetUserBooks(userid);
        }

        public Result ReturnBook(int userid,int bookid)
        {
            if(!_bookRepository.IsBarrowedBefore(bookid))
            {
                return new Result(false,"The choosen book is not barrowed to be returned.choose a barrowed book.");
            }
           var book =_bookRepository.GetUserBarrowedBId(userid , bookid);
          if(_bookRepository.Return(book))
            {
                return new Result(true, "Book returned");
            }
            return new Result(false, "Could not return book");
        }
    }
}
