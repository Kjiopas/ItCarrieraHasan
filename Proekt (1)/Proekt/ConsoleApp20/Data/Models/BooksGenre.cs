using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20.Data.Models
{
    public class BooksGenre
    {
        [Key]
        public int Id { get; set; }
        public string BookGenre { get; set; }
        public int BookId { get; set; }
        [ForeignKey("BookId")]    
        public Books Book { get; set; } 
    }
}
