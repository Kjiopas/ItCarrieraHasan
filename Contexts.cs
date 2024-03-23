using ConsoleApp20.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20.Data
{
    public class Contexts:DbContext
    {
        public Contexts() : base()
        {
        }

        public Contexts([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Books> Books { get; set; }
        public  virtual DbSet<Films> Films { get; set; } 
        public virtual DbSet<BooksGenre> BooksGenre { get; set; }
        public virtual DbSet<FilmsGenre> FilmsGenre { get; set; }
        public  virtual DbSet<Book_Premiere> Book_Premiere { get; set; }
        public virtual DbSet<Film_Premiere> Film_Premiere { get; set; } 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server =DESKTOP-HAA9A2O\SQLEXPRESS  ; Database = projectitkariera2; Integrated security = true");
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
