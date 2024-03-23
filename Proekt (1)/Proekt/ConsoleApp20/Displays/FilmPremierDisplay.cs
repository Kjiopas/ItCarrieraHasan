using ConsoleApp20.Bussiness;
using ConsoleApp20.Data.Models;
using System;

namespace ConsoleApp20.Displays
{
    public class FilmPremiereDisplay
    {
        private Film_Premiere_Business filmPremiereBusiness;
        private const int ExitOption = 6;

        public FilmPremiereDisplay()
        {
            filmPremiereBusiness = new Film_Premiere_Business(); // Initialize filmPremiereBusiness
            Inputs();
        }

        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 10) + "FILM PREMIERES MENU" + new string(' ', 10));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all Film Premieres");
            Console.WriteLine("2. Add new Film Premiere");
            Console.WriteLine("3. Update Film Premiere information");
            Console.WriteLine("4. Find the Film Premiere by ID");
            Console.WriteLine("5. Delete the Film Premiere by ID");
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
                        ListAllFilmPremieres();
                        break;
                    case 2:
                        AddFilmPremiere();
                        break;
                    case 3:
                        UpdateFilmPremiere();
                        break;
                    case 4:
                        GetFilmPremiereInformation();
                        break;
                    case 5:
                        RemoveFilmPremiere();
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

        private void ListAllFilmPremieres()
        {
            var filmPremieres = filmPremiereBusiness.GetAllFilmPremieres();

            if (filmPremieres == null || filmPremieres.Count == 0)
            {
                Console.WriteLine("No film premieres found.");
                return;
            }

            foreach (var premiere in filmPremieres)
            {
                Console.WriteLine($"{premiere.film_premiere_Id} {premiere.film_Id} {premiere.date} {premiere.city}");
            }
        }

        private void AddFilmPremiere()
        {
            Film_Premiere filmPremiere = new Film_Premiere();


            Console.Write("Enter date (YYYY-MM-DD): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime date))
            {
                Console.WriteLine("Invalid input for date. Please enter a valid date in the format YYYY-MM-DD.");
                return;
            }
            filmPremiere.date = date;
            Console.Write("Enter city: ");
            filmPremiere.city = Console.ReadLine();
            Console.Write("Enter film_id: ");
            filmPremiere.film_Id = int.Parse(Console.ReadLine());

            filmPremiereBusiness.AddNewFilm_premiere(filmPremiere);
        }

        private void RemoveFilmPremiere()
        {
            Console.Write("Enter ID to remove: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive number.");
                return;
            }

            bool success = filmPremiereBusiness.RemoveFilmPremiere(id);
            if (success)
            {
                Console.WriteLine("The film premiere has been successfully deleted!");
            }
            else
            {
                Console.WriteLine("Film premiere not found!");
            }
        }

        private void UpdateFilmPremiere()
        {
            Console.Write("Enter ID to update: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid positive number.");
                return;
            }

            Film_Premiere filmPremiere = filmPremiereBusiness.GetFilmPremiereById(id);
            if (filmPremiere != null)
            {
                Console.WriteLine($"{filmPremiere.film_premiere_Id} {filmPremiere.film_Id} {filmPremiere.date} {filmPremiere.city}");


                Console.Write("Enter the new date (YYYY-MM-DD): ");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime newDate))
                {
                    Console.WriteLine("Invalid input for date. Please enter a valid date in the format YYYY-MM-DD.");
                    return;
                }
                filmPremiere.date = newDate;

                Console.Write("Enter the new city: ");
                filmPremiere.city = Console.ReadLine();

                try
                {
                    filmPremiereBusiness.UpdateFilmPremiere(filmPremiere);
                    Console.WriteLine("Film premiere updated successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating film premiere: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Film premiere not found");
            }
        }

        private void GetFilmPremiereInformation()
        {
            Console.Write("Enter the film premiere's ID: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                return;
            }

            Film_Premiere filmPremiere = filmPremiereBusiness.GetFilmPremiereById(id);
            if (filmPremiere != null)
            {
                Console.WriteLine($"{filmPremiere.film_premiere_Id} {filmPremiere.film_Id} {filmPremiere.date} {filmPremiere.city}");
            }
            else
            {
                Console.WriteLine("Film premiere not found");
            }
        }
    }
}
