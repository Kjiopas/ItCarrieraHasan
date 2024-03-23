using ConsoleApp20.Data;
using ConsoleApp20.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20.Bussiness
{
    public class Film_Premiere_Business
    {
        private Contexts Context;
        
        public Film_Premiere_Business()
        {
            Context = new Contexts();
        }

        public Film_Premiere_Business(Contexts context)
        {
            Context = context;
        }
        public List<Film_Premiere> GetAllFilmPremieres()
        {
            using (var context = new Contexts())
            {
                return context.Film_Premiere.ToList();
            }
        }

        public Film_Premiere GetFilmPremiereById(int id)
        {
            using (var context = new Contexts())
            {
                return context.Film_Premiere.Find(id);
            }
        }

        public void AddNewFilm_premiere(Film_Premiere premiere)
        {
            using (var context = new Contexts())
            {
          
               
                    context.Film_Premiere.Add(premiere);
                context.SaveChanges();  
                

                
                
            }
        }
        public bool RemoveFilmPremiere(int id)
        {
            using (var context = new Contexts())
            {
                var find = context.Film_Premiere.Find(id);
                if (find != null)
                {
                    context.Film_Premiere.Remove(find);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public void UpdateFilmPremiere(Film_Premiere premiere)
        {
            using (var context = new Contexts())
            {
                var find = context.Film_Premiere.Find(premiere.film_premiere_Id);
                if (find != null)
                {
                    context.Entry(find).CurrentValues.SetValues(premiere);
                    context.SaveChanges();
                }
            }
        }
    }

}
