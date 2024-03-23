using ConsoleApp20.Data.Models;
using ConsoleApp20.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20.Bussiness
{
    public class BookBussiness
    {
      
        private Contexts Context;
        public BookBussiness()
        {
            Context = new Contexts();   
        }
       
        public BookBussiness(Contexts context)
        {
            Context = context;
        }

        public List<Books> GetAllBooks()
        {
            using (var context = new Contexts())
            {
                return context.Books.ToList();
            }
        }

        public Books GetBookById(int id)
        {
            using (var context = new Contexts())
            {
                return context.Books.Find(id);
            }
        }

        public void AddNewBook(Books book)
        {
            using (var context = new Contexts())
            {
                context.Books.Add(book);
                context.SaveChanges();
            }
        }
        public bool RemoveBook(int id)
        {
            using (var context = new Contexts())
            {
                var find = context.Books.Find(id);
                if (find != null)
                {
                    context.Books.Remove(find);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public void UpdateBook(Books book)
        {
            using (var context = new Contexts())
            {
                var find = context.Books.Find(book.id);
                if (find != null)
                {
                    context.Entry(find).CurrentValues.SetValues(book);
                    context.SaveChanges();
                }
            }
        }
    }
}
