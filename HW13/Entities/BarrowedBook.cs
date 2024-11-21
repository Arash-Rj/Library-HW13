using HW13.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW13.Entities
{
    public class BarrowedBook
    {
        [Key]
        public int Number { get; set; }
        [Column("BookTitle" , TypeName = "varchar(100)")]
        public string Title { get; set; }
        [MaxLength(50)]
        public string Author { get; set; }

        public GenreEnum Genre { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime BarrowDate { get; set; }
        public Book Book { get; set; }
        public int BookId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public BarrowedBook(Book book, int userid) 
        {
            Title = book.Title;
            Author = book.Author;
            Genre = book.Genre;
            UserId= userid;
            BookId = book.Id;
            book.Status = StatusEnum.Barrowed;
            BarrowDate = DateTime.Now;
        }
        public BarrowedBook() { }
        public override string ToString()
        {
            return $"BookId: {BookId} | Title: {Title} | Author : {Author} " +
                $"| Genre: {Genre.ToString()} | Barrowe Date: {BarrowDate.ToString()}";
        }
    }
}
