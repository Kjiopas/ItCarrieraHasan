using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20.Data.Models
{
    public class FilmsGenre
    {
        [Key]
        public int Id { get; set; }
        public string FilmsGenres { get; set; }
        public int FilmId { get; set; }
        [ForeignKey("FilmId")]
        public virtual Films Film { get; set; }
    }
}
