using ConsoleApp20.Bussiness;
using ConsoleApp20.Data.Models;
using System;

namespace ConsoleApp20.Displays
{
    public class BooksPremiersDisplay
    {
        private BookPremiereBusiness bookBusiness;
        private const int ExitOption = 6;

        public BooksPremiersDisplay()
        {
            bookBusiness = new BookPremiereBusiness(); // Initialize bookBusiness
            Inputs();
        }

        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 10) + "Book Premier MENU" + new string(' ', 10));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all BookPremieres");
            Console.WriteLine("2. Add new BookPremiere");
            Console.WriteLine("3. Update BookPremier's information");
            Console.WriteLine("4. Find the BookPremier by ID");
            Console.WriteLine("5. Delete the BookPremier by ID");
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
                        ListAllBooksPremieres();
                        break;
                    case 2:
                        AddBookPremiere();
                        break;
                    case 3:
                        UpdateBookPremiere();
                        break;
                    case 4:
                        GetBookInformation();
                        break;
                    case 5:
                        RemoveBook();
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

        private void ListAllBooksPremieres()
        {
            var books = bookBusiness.GetAllBookPremieres();

            if (books == null || books.Count == 0)
            {
                Console.WriteLine("No book premieres found.");
                return;
            }

            foreach (var book in books)
            {
                Console.WriteLine($"{book.Premiere_Id} {book.book_Id} {book.city} {book.date}");
            }
        }

        private void AddBookPremiere()
        {
            Book_Premiere book = new Book_Premiere();

            Console.Write("Enter city: ");
            book.city = Console.ReadLine();
            Console.Write("Enter date (YYYY-MM-DD): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime date))
            {
                Console.WriteLine("Invalid input for date. Please enter a valid date in the format YYYY-MM-DD.");
                return;
            }
            book.date = date;
            Console.Write("Enter book_id");
            book.book_Id=int.Parse(Console.ReadLine()); 

            bookBusiness.AddNewBookPremiere(book);
        }

        private void RemoveBook()
        {
            Console.Write("Enter ID to remove: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive number.");
                return;
            }

            bool success = bookBusiness.RemoveBookPremiere(id);
            if (success)
            {
                Console.WriteLine("The book has been successfully deleted!");
            }
            else
            {
                Console.WriteLine("Book not found!");
            }
        }

        private void UpdateBookPremiere()
        {
            Console.Write("Enter ID to update: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid positive number.");
                return;
            }

            Book_Premiere book = bookBusiness.GetBookPremiereById(id);
            if (book != null)
            {
                Console.WriteLine($"{book.book_Id} {book.city} {book.date}");
                Console.Write("Enter the new city: ");
                book.city = Console.ReadLine();

                Console.Write("Enter the new date (YYYY-MM-DD): ");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime newDate))
                {
                    Console.WriteLine("Invalid input for date. Please enter a valid date in the format YYYY-MM-DD.");
                    return;
                }
                book.date = newDate;

                try
                {
                    bookBusiness.UpdateBookPremiere(book);
                    Console.WriteLine("Book updated successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating book: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Book not found");
            }
        }

        public void GetBookInformation()
        {
            Console.Write("Enter the book's ID: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                return;
            }

            Book_Premiere book = bookBusiness.GetBookPremiereById(id);
            if (book != null)
            {
                Console.WriteLine($"{book.book_Id} {book.city} {book.date}");
            }
            else
            {
                Console.WriteLine("Book not found");
            }
        }
    }
}
