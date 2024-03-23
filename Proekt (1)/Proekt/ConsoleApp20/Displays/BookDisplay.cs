using ConsoleApp20.Bussiness;
using ConsoleApp20.Data.Models;
using System;

namespace ConsoleApp20.Displays
{
    public class BooksDisplay
    {
        private BookBussiness bookBussiness;
        private const int ExitOption = 6;

        public BooksDisplay()
        {
            bookBussiness = new BookBussiness(); // Initialize bookBussiness
            Inputs();
        }

        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 10) + "MENU" + new string(' ', 10));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all Books");
            Console.WriteLine("2. Add new Book");
            Console.WriteLine("3. Update Book's information");
            Console.WriteLine("4. Find the Book by ID");
            Console.WriteLine("5. Delete the Book by ID");
            Console.WriteLine($"{ExitOption}. Exit");
        }

        private void Inputs()
        {
            int choice ;

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
                        ListAllBooks();
                        break;
                    case 2:
                        AddBook();
                        break;
                    case 3:
                        UpdateBook();
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
        
        private void ListAllBooks()
        {
            var books = bookBussiness.GetAllBooks();

            if (books == null || books.Count == 0)
            {
                Console.WriteLine("No books found.");
                return;
            }

            foreach (var book in books)
            {
                Console.WriteLine($"{book.id} {book.price} {book.author} {book.name}");
            }
        }

        private void AddBook()
        {
            Books book = new Books();

            Console.Write("Enter price: ");
            book.price = decimal.Parse(Console.ReadLine());
            Console.Write("Enter author's name: ");
            book.author = Console.ReadLine();
            Console.Write("Enter book's name: ");
            book.name = Console.ReadLine();
            bookBussiness.AddNewBook(book);
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

            bool success = bookBussiness.RemoveBook(id);
            if (success)
            {
                Console.WriteLine("The book has been successfully deleted!");
            }
            else
            {
                Console.WriteLine("Book not found!");
            }
        }




        private void UpdateBook()
        {
            Console.Write("Enter ID to update: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid positive number.");
                return;
            }

            Books book = bookBussiness.GetBookById(id);
            if (book != null)
            {
                Console.WriteLine($"{book.id} {book.price} {book.author} {book.name}");
                Console.Write("Enter the new author's name: ");
                book.author = Console.ReadLine();

                decimal newPrice;
                Console.Write("Enter the new price: ");
                if (!decimal.TryParse(Console.ReadLine(), out newPrice))
                {
                    Console.WriteLine("Invalid input for price. Please enter a valid decimal value.");
                    return;
                }
                book.price = newPrice;

                Console.Write("Enter the new name of the book: ");
                book.name = Console.ReadLine();

                try
                {
                    // Call the UpdateBook method of the BookBusiness class
                    bookBussiness.UpdateBook(book);
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

            Books book = bookBussiness.GetBookById(id);
            if (book != null)
            {
                Console.WriteLine($"{book.id} {book.price} {book.author} {book.name}");
            }
            else
            {
                Console.WriteLine("Book not found");
            }
        }
    }
}
