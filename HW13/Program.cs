using HW13.Entities;
using HW13.Enum;
using HW13.Service;

BookService bookService = new BookService();
UserService userService = new UserService();
bool isfinished = false;
do
{
    Console.Clear();
    Console.WriteLine("*****Welcome To The Library*****");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("1.Login");
    Console.WriteLine("2.Sign up");
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("3.Logout");
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.WriteLine("******************************");
    int choice = 0;
    try
    {
        choice = Int32.Parse(Console.ReadLine());
    }
    catch (FormatException)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid format entered.Try again.");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("Press any key...");
        Console.ReadKey();
    }
    switch (choice)
    {
        case 1:
            Console.Clear();
            Login();
            break;
        case 2:
            Console.Clear();
            Register();
            Console.ReadKey();
            break;
        case 3:
            Console.Clear();
            userService.Logout();
            isfinished = true;
            break;
    }
} while (!isfinished);
void Login()
{
    Console.Clear();
    Console.Write("Please enter your email: ");
    var email = Console.ReadLine();
    Console.Write("Please enter your password: ");
    var password = Console.ReadLine();
    var res = userService.Login(email,password);
    ResultMessage(res);
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("Press any key...");
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.ReadKey();
    if (res.IsDone == true && OnlineUser.user.Role==RoleEnum.Member)
    { 
        membermenu(OnlineUser.user); 
    }
    else if(res.IsDone && OnlineUser.user.Role == RoleEnum.Librarian)
    {
        LibrarianMenu(OnlineUser.user);
    }
}
void Register()
{
    Console.Write("Please enter your name: ");
    var name = Console.ReadLine();
    Console.Write("Please enter your email: ");
    var email = Console.ReadLine();
    Console.Write("Please enter your password: ");
    var password = Console.ReadLine();
    Console.WriteLine("Please choose your role: ");
    Console.WriteLine("1.Librarian     2.Member");
    var choice = int.Parse(Console.ReadLine());
    var res = userService.Register(name, email, password,(RoleEnum)choice);
    ResultMessage(res);
    if (res.IsDone == true)
    {
        Console.WriteLine("1.Advance to menu     2.Peace out");
        int res1 = 0;
        try
        { res1 = Int32.Parse(Console.ReadLine()); }
        catch (FormatException)
        {
            Console.Clear();
            Console.WriteLine("Invalid format entered.Try again.");
            Console.WriteLine("Press any key...");
        }
        if (res1 == 1)
        {
            Login();
        }
    }
    else
    {
        Console.WriteLine("Press any key...");
    }
}
void membermenu(User user)
{
    bool isfinished = false;
    do
    {
        Console.Clear();
        Console.WriteLine("******Welcome******");
        Console.WriteLine("1.Barrow a book.");
        Console.WriteLine("2.Return a book.");
        Console.WriteLine("3.List Of Barrowed books.");
        Console.WriteLine("4.List of library books.");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("5.Peace out.");
        Console.ForegroundColor = ConsoleColor.Gray;
        if (!Int32.TryParse(Console.ReadLine(), out int res))
        {
            Console.WriteLine("Invalid format please try again.");
        }
            switch(res)
            {
                case 1:
                Console.Clear();
                LibraryBooksList(user.Id);
                Console.Write("Enter The book id: ");
                var bookid = int.Parse(Console.ReadLine());
                var result = bookService.BarrowBook(user.Id,bookid);
                ResultMessage(result);
                break;
                case 2:
                Console.Clear();
                UserBooksList(user.Id);
                Console.Write("Enter BookId: ");
                var bid = int.Parse(Console.ReadLine());
                var resu = bookService.ReturnBook(user.Id,bid);
                ResultMessage(resu);
                    break;
                case 3:
                Console.Clear();
                UserBooksList(user.Id);
                    break;
                case 4:
                Console.Clear();
                LibraryBooksList(user.Id);
                    break;
                case 5:
                Console.Clear();
                userService.Logout();
                isfinished = true;
                    break;
            }
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Press any key...");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.ReadKey();
    }
    while (!isfinished);
}
void LibrarianMenu(User user)
{
    bool isfinished = false;
    do
    {
        Console.Clear();
        Console.WriteLine("******Welcome******");
        Console.WriteLine("1.Library Books.");
        Console.WriteLine("2.Users List.");
        Console.WriteLine("3.Change User Subscription date.");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("4.Peace out.");
        Console.ForegroundColor = ConsoleColor.Gray;
        if (!Int32.TryParse(Console.ReadLine(), out int res))
        {
            Console.WriteLine("Invalid format please try again.");
        }
        switch(res)
        {
            case 1:
                Console.Clear();
                LibraryBooksList(user.Id);
                break;
            case 2:
                Console.Clear();
                UsersList();
                break;
            case 3:
                Console.Clear();
                UsersList();
                Console.Write("Enter User ID: ");
                var uid = int.Parse(Console.ReadLine());
                Console.Write("Enter New subscription end date (yyyy/mm/dd) : ");
                var duedate = Console.ReadLine();
                var r = userService.changeSubscriptinoDate(uid, duedate);
                ResultMessage(r);
                break;
            case 4:
                userService.Logout();
                isfinished = true;
                break;
        }
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Press any key...");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.ReadKey();
    }
    while(!isfinished);
}
void LibraryBooksList(int userid)
{
    var librarybooks = bookService.GetLibraryBookList();
    var librarybooks2 = new List<Book>();
    if(!userService.IsUserAdmin(userid))
    {
        var userbooklist = bookService.GetUserBookList(userid);
        if (userbooklist.Count!=0)
        {
            foreach (var book in librarybooks)
            {
                foreach (var b in userbooklist)
                {
                    if (book.Id != b.BookId)
                    {
                        librarybooks2.Add(book);
                    }
                }
            }
            librarybooks = librarybooks2;
        }
    }
    Console.WriteLine("*******Library Books*******");
    librarybooks.ForEach(b => Console.WriteLine(b.ToString()));
    Console.WriteLine("***************************");
}
void UserBooksList(int userid)
{
    var ubook = bookService.GetUserBookList(userid);
    Console.WriteLine("*******User Books*******");
    if (ubook.Count==0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("NO Book barrowed");
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    else
    {
        ubook.ForEach(b => Console.WriteLine(b.ToString()));
    }
    Console.WriteLine("***************************");
}
void ResultMessage(Result result)
{
    if (result.IsDone)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(result.Message);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(result.Message);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
}
void UsersList()
{
    var users = userService.GetAllUsers();
    Console.WriteLine("**** Users ****");
    users.ForEach(u => Console.WriteLine(u.ToString()));
    Console.WriteLine("****************");
}