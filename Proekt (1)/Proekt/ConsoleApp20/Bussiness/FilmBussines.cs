using ConsoleApp20.Data.Models;
using ConsoleApp20.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20.Bussiness
{
    public class FilmBussiness
    {

        private Contexts Context;
        public FilmBussiness()
        {
            Context = new Contexts();
        }

        public FilmBussiness(Contexts context)
        {
            Context = context;
        }

        public List<Films> GetAllFilms()
        {
            using (var context = new Contexts())
            {
                return context.Films.ToList();
            }
        }

        public Films GetFilmByid(int id)
        {
            using (var context = new Contexts())
            {
                return context.Films.Find(id);
            }
        }

        public void AddNewFilm(Films film)
        {
            using (var context = new Contexts())
            {
                context.Films.Add(film);
                context.SaveChanges();
            }
        }
        public bool RemoveFilm(int id)
        {
            using (var context = new Contexts())
            {
                var find = context.Films.Find(id);
                if (find != null)
                {
                    context.Films.Remove(find);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public void UpdateFilm(Films film)
        {
            using (var context = new Contexts())
            {
                var find = context.Films.Find(film.id);
                if (find != null)
                {
                    context.Entry(find).CurrentValues.SetValues(film);
                    context.SaveChanges();
                }
            }
        }
    }
}
