using ConsoleApp20.Data.Models;
using ConsoleApp20.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp20.Bussiness
{
    public class BookPremiereBusiness
    {
        private Contexts Context;

        public BookPremiereBusiness()
        {
            Context = new Contexts();
        }

        public BookPremiereBusiness(Contexts context)
        {
            Context = context;
        }

        public List<Book_Premiere> GetAllBookPremieres()
        {
            using (var context = new Contexts())
            {
                return context.Book_Premiere.ToList();
            }
        }

        public Book_Premiere GetBookPremiereById(int id)
        {
            using (var context = new Contexts())
            {
                return context.Book_Premiere.Find(id);
            }
        }

        public void AddNewBookPremiere(Book_Premiere bookPremiere)
        {
            using (var context = new Contexts())
            {
                context.Book_Premiere.Add(bookPremiere);
                context.SaveChanges();
            }
        }

        public bool RemoveBookPremiere(int id)
        {
            using (var context = new Contexts())
            {
                var find = context.Book_Premiere.Find(id);
                if (find != null)
                {
                    context.Book_Premiere.Remove(find);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public void UpdateBookPremiere(Book_Premiere bookPremiere)
        {
            using (var context = new Contexts())
            {
                var find = context.Book_Premiere.Find(bookPremiere.book_Id);
                
                if (find != null)
                {
                    context.Entry(find).CurrentValues.SetValues(bookPremiere);
                    context.SaveChanges();
                }
            }
        }
    }
}
