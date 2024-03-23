using ConsoleApp20.Bussiness;
using ConsoleApp20.Data.Models;
using System;

namespace ConsoleApp20.Displays
{
    public class FilmsDisplay
    {
        private FilmBussiness filmBussiness;
        private const int ExitOption = 6;

        public FilmsDisplay()
        {
            filmBussiness = new FilmBussiness(); // Initialize filmBussiness
            Inputs();
        }

        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 10) + "MENU" + new string(' ', 10));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all Films");
            Console.WriteLine("2. Add new Film");
            Console.WriteLine("3. Update Films's information");
            Console.WriteLine("4. Find the Film by ID");
            Console.WriteLine("5. Delete the Film by ID");
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
                        ListAllFilms();
                        break;
                    case 2:
                        AddFilm();
                        break;
                    case 3:
                        UpdateFilm();
                        break;
                    case 4:
                        GetFilmInformation();
                        break;
                    case 5:
                        RemoveFilm();
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

        private void ListAllFilms()
        {
            var films = filmBussiness.GetAllFilms();

            if (films == null || films.Count == 0)
            {
                Console.WriteLine("No films found.");
                return;
            }

            foreach (var film in films)
            {
                Console.WriteLine($"{film.id} {film.price} {film.director_name} {film.name}");
            }
        }

        private void AddFilm()
        {
            Films film = new Films();

            Console.Write("Enter price: ");
            film.price = decimal.Parse(Console.ReadLine());
            Console.Write("Enter director_name's name: ");
            film.director_name = Console.ReadLine();
            Console.Write("Enter film's name: ");
            film.name = Console.ReadLine();
            filmBussiness.AddNewFilm(film);
        }

        private void RemoveFilm()
        {
            Console.Write("Enter ID to remove: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive number.");
                return;
            }

            bool success = filmBussiness.RemoveFilm(id);
            if (success)
            {
                Console.WriteLine("The film has been successfully deleted!");
            }
            else
            {
                Console.WriteLine("Film not found!");
            }
        }




        private void UpdateFilm()
        {
            Console.Write("Enter ID to update: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid positive number.");
                return;
            }

            Films film = filmBussiness.GetFilmByid(id);
            if (film != null)
            {
                Console.WriteLine($"{film.id} {film.price} {film.director_name} {film.name}");
                Console.Write("Enter the new director_name's name: ");
                film.director_name = Console.ReadLine();

                decimal newPrice;
                Console.Write("Enter the new price: ");
                if (!decimal.TryParse(Console.ReadLine(), out newPrice))
                {
                    Console.WriteLine("Invalid input for price. Please enter a valid decimal value.");
                    return;
                }
                film.price = newPrice;

                Console.Write("Enter the new name of the film: ");
                film.name = Console.ReadLine();

                try
                {
                    // Call the UpdateFilm method of the FilmBusiness class
                    filmBussiness.UpdateFilm(film);
                    Console.WriteLine("Film updated successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating film: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Film not found");
            }
        }

        public void GetFilmInformation()
        {
            Console.Write("Enter the film's ID: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                return;
            }

            Films film = filmBussiness.GetFilmByid(id);
            if (film != null)
            {
                Console.WriteLine($"{film.id} {film.price} {film.director_name} {film.name}");
            }
            else
            {
                Console.WriteLine("Film not found");
            }
        }
    }
}
