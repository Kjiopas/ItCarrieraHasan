using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20.Data.Models
{
    public class Book_Premiere
    {
        [Key]
        public int Premiere_Id { get; set; } 
        public int book_Id { get; set; }
        public string city { get; set; }
        public DateTime date { get; set; }
        [ForeignKey("book_Id")]
        public virtual Books Books {get;set;}
    }
}
