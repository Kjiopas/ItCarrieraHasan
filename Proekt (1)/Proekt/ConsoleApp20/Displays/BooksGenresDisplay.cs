using ConsoleApp20.Bussiness;
using ConsoleApp20.Data.Models;
using System;

namespace ConsoleApp20.Displays
{
    public class BookGenreDisplay
    {
        private Book_Genre_Business bookGenreBusiness;
        private const int ExitOption = 6;

        public BookGenreDisplay()
        {
            bookGenreBusiness = new Book_Genre_Business(); // Initialize bookGenreBusiness
            Inputs();
        }

        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 10) + "BOOK GENRES MENU" + new string(' ', 10));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all Book Genres");
            Console.WriteLine("2. Add new Book Genre");
            Console.WriteLine("3. Update Book Genre information");
            Console.WriteLine("4. Find the Book Genre by ID");
            Console.WriteLine("5. Delete the Book Genre by ID");
            Console.WriteLine($"{ExitOption}. Exit");
        }

        private void Inputs()
        {
            int choice;

            do
            {
                ShowMenu();
                Console.Write("Enter your choice: ");
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        ListAllBookGenres();
                        break;
                    case 2:
                        AddBookGenre();
                        break;
                    case 3:
                        UpdateBookGenre();
                        break;
                    case 4:
                        GetBookGenreInformation();
                        break;
                    case 5:
                        RemoveBookGenre();
                        break;
                    case ExitOption:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            } while (choice != ExitOption);
        }

        private void ListAllBookGenres()
        {
            var bookGenres = bookGenreBusiness.GetAllBookGenres();

            if (bookGenres == null || bookGenres.Count == 0)
            {
                Console.WriteLine("No book genres found.");
                return;
            }

            foreach (var genre in bookGenres)
            {
                Console.WriteLine($"{genre.Id} {genre.BookGenre} {genre.BookId}");
            }
        }

        private void AddBookGenre()
        {
            BooksGenre bookGenre = new BooksGenre();

            Console.Write("Enter book genre: ");
            bookGenre.BookGenre = Console.ReadLine();

            Console.Write("Enter book ID: ");
            if (!int.TryParse(Console.ReadLine(), out int bookId))
            {
                Console.WriteLine("Invalid input for book ID. Please enter a valid number.");
                return;
            }
            bookGenre.BookId = bookId;

            bookGenreBusiness.AddNewBookGenre(bookGenre);
        }

        private void RemoveBookGenre()
        {
            Console.Write("Enter ID to remove: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive number.");
                return;
            }

            bool success = bookGenreBusiness.RemoveBookGenre(id);
            if (success)
            {
                Console.WriteLine("The book genre has been successfully deleted!");
            }
            else
            {
                Console.WriteLine("Book genre not found!");
            }
        }

        private void UpdateBookGenre()
        {
            Console.Write("Enter ID to update: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid positive number.");
                return;
            }

            BooksGenre bookGenre = bookGenreBusiness.GetBookGenreById(id);
            if (bookGenre != null)
            {
                Console.WriteLine($"{bookGenre.Id} {bookGenre.BookGenre} {bookGenre.BookId}");

                Console.Write("Enter the new book genre: ");
                bookGenre.BookGenre = Console.ReadLine();

                Console.Write("Enter the new book ID: ");
                if (!int.TryParse(Console.ReadLine(), out int newBookId))
                {
                    Console.WriteLine("Invalid input for book ID. Please enter a valid number.");
                    return;
                }
                bookGenre.BookId = newBookId;

                try
                {
                    bookGenreBusiness.UpdateBookGenre(bookGenre);
                    Console.WriteLine("Book genre updated successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating book genre: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Book genre not found");
            }
        }

        private void GetBookGenreInformation()
        {
            Console.Write("Enter the book genre's ID: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                return;
            }

            BooksGenre bookGenre = bookGenreBusiness.GetBookGenreById(id);
            if (bookGenre != null)
            {
                Console.WriteLine($"{bookGenre.Id} {bookGenre.BookGenre} {bookGenre.BookId}");
            }
            else
            {
                Console.WriteLine("Book genre not found");
            }
        }
    }
}
