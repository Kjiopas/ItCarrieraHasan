using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20.Data.Models
{
    public class Film_Premiere
    {
        [Key]
        public int film_premiere_Id { get; set; }
        public int film_Id { get; set; }
        public string city { get; set; }
        public System.DateTime date { get; set; }
        [ForeignKey("film_Id")]
        public virtual  Films films { get; set; }
    }
}
