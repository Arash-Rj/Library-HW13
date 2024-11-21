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
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Column("BookTitle", TypeName = "varchar(100)")]
        public string Title { get; set; }
        [MaxLength(50)]
        public string Author { get; set; }
        [Column("Genre Id")]
        public GenreEnum Genre { get; set; }
        [Column("Status number")]
        public StatusEnum Status { get; set; }
        public BarrowedBook books { get; set; }
        public override string ToString()
        {
            return $"BookId: {Id} | Title: {Title} | Author : {Author} " +
                $"| Genre: {Genre.ToString()} | Status: {Status.ToString()}";
        }
    }
}
