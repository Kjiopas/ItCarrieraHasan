using ConsoleApp20.Data;
using ConsoleApp20.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp20.Bussiness
{
    public class Book_Genre_Business
    {
        private Contexts Context;

        public Book_Genre_Business()
        {
            Context = new Contexts();
        }

        public Book_Genre_Business(Contexts context)
        {
            Context = context;
        }

        public List<BooksGenre> GetAllBookGenres()
        {
            using (var context = new Contexts())
            {
                return context.BooksGenre.ToList();
            }
        }

        public BooksGenre GetBookGenreById(int id)
        {
            using (var context = new Contexts())
            {
                return context.BooksGenre.Find(id);
            }
        }

        public void AddNewBookGenre(BooksGenre premiere)
        {
            using (var context = new Contexts())
            {
                
                    context.BooksGenre.Add(premiere);
                    context.SaveChanges();
               
            }
        }

        public bool RemoveBookGenre(int id)
        {
            using (var context = new Contexts())
            {
                var find = context.BooksGenre.Find(id);
                if (find != null)
                {
                    context.BooksGenre.Remove(find);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public void UpdateBookGenre(BooksGenre genre)
        {
            using (var context = new Contexts())
            {
                var find = context.BooksGenre.Find(genre);
                if (find != null)
                {
                    context.Entry(find).CurrentValues.SetValues(genre);
                    context.SaveChanges();
                }
            }
        }
    }
}