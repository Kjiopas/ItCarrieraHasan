using ConsoleApp20.Data;
using ConsoleApp20.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20.Bussiness
{
    public class FilmGenreBussiness
    {
        private Contexts Context;

        public FilmGenreBussiness()
        {
            Context = new Contexts();
        }

        public FilmGenreBussiness(Contexts context)
        {
            Context = context;
        }
        public List<FilmsGenre> GetAllFilmGenres()
        {
            using (var context = new Contexts())
            {
                return context.FilmsGenre.ToList();
            }
        }

        public FilmsGenre GetFilmGenreById(int id)
        {
            using (var context = new Contexts())
            {
                return context.FilmsGenre.Find(id);
            }
        }

        public void AddNewFilmGenre(FilmsGenre genre)
        {
            using (var context = new Contexts())
            {
                context.FilmsGenre.Add(genre);
                context.SaveChanges();

            }
        }
        public bool RemoveFilmGenre(int id)
        {
            using (var context = new Contexts())
            {
                var find = context.FilmsGenre.Find(id);
                if (find != null)
                {
                    context.FilmsGenre.Remove(find);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public void UpdateFilmGenre(FilmsGenre genre)
        {
            using (var context = new Contexts())
            {
                var find = context.FilmsGenre.Find(genre.Id);
                if (find != null)
                {
                    context.Entry(find).CurrentValues.SetValues(genre);
                    context.SaveChanges();
                }
            }
        }
    }

}
