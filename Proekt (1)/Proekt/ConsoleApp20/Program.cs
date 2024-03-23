using ConsoleApp20.Bussiness;
using ConsoleApp20.Displays;
using System;

namespace ConsoleApp20
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            do
            {
                Show();
                n = int.Parse(Console.ReadLine());
                switch (n)
                {
                    case 1: BooksDisplay display = new BooksDisplay(); break;
                    case 2: FilmsDisplay display1 = new FilmsDisplay(); break;
                    case 3: BookGenreDisplay display2 = new BookGenreDisplay(); break;
                    case 4: FilmGenreDisplay display3 = new FilmGenreDisplay(); break;
                    case 5: BooksPremiersDisplay display4 = new BooksPremiersDisplay(); break;
                    case 6: FilmPremiereDisplay display5 = new FilmPremiereDisplay(); break;
                    case 7:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;

                }
            }
            while (n != 7);

            
        }

       

        public static void Show()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 10) + "Main MENU" + new string(' ', 10));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("Which Display would you like to choose");
            Console.WriteLine("1.BookDisplay");
            Console.WriteLine("2.FilmsDisplay");
            Console.WriteLine("3.BookGenreDisplay");
            Console.WriteLine("4.FilmGenreDisplay");
            Console.WriteLine("5.BooksPremiersDisplay");
            Console.WriteLine("6.FilmPremiereDisplay");
            Console.WriteLine("7.Exit");
        }
    }
}
