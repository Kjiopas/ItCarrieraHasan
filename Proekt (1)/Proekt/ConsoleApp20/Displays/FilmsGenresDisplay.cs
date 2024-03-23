using ConsoleApp20.Bussiness;
using ConsoleApp20.Data.Models;
using System;

namespace ConsoleApp20.Displays
{
    public class FilmGenreDisplay
    {
        private FilmGenreBussiness filmGenreBusiness;
        private const int ExitOption = 6;

        public FilmGenreDisplay()
        {
            filmGenreBusiness = new FilmGenreBussiness(); // Initialize filmGenreBussiness
            Inputs();
        }

        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 10) + "FILM PREMIERES MENU" + new string(' ', 10));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all Film Genres");
            Console.WriteLine("2. Add new Film Genres");
            Console.WriteLine("3. Update Film Genres information");
            Console.WriteLine("4. Find the Film Genres by ID");
            Console.WriteLine("5. Delete the Film Genres by ID");
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
                        ListAllFilmGenre();
                        break;
                    case 2:
                        AddFilmGenre();
                        break;
                    case 3:
                        UpdateFilmGenre();
                        break;
                    case 4:
                        GetFilmGenreInformation();
                        break;
                    case 5:
                        RemoveFilmGenre();
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

        private void ListAllFilmGenre()
        {
            var filmGenres = filmGenreBusiness.GetAllFilmGenres();

            if (filmGenres == null || filmGenres.Count == 0)
            {
                Console.WriteLine("No film genres found.");
                return;
            }

            foreach (var genre in filmGenres)
            {
                Console.WriteLine($"{genre.Id} {genre.FilmId} {genre.FilmsGenres}");
            }
        }

        private void AddFilmGenre()
        {
            FilmsGenre filmGenre = new FilmsGenre();
            Console.Write("Enter Genre: ");
            filmGenre.FilmsGenres = Console.ReadLine();
            
            Console.Write("Enter film_id: ");
            filmGenre.FilmId = int.Parse(Console.ReadLine());

            filmGenreBusiness.AddNewFilmGenre(filmGenre);
        }

        private void RemoveFilmGenre()
        {
            Console.Write("Enter ID to remove: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive number.");
                return;
            }

            bool success = filmGenreBusiness.RemoveFilmGenre(id);
            if (success)
            {
                Console.WriteLine("The film genre has been successfully deleted!");
            }
            else
            {
                Console.WriteLine("Film genre not found!");
            }
        }

        private void UpdateFilmGenre()
        {
            Console.Write("Enter ID to update: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid positive number.");
                return;
            }

            FilmsGenre filmGenre = filmGenreBusiness.GetFilmGenreById(id);
            if (filmGenre != null)
            {
                Console.WriteLine($"{filmGenre.Id} {filmGenre.FilmId} {filmGenre.FilmsGenres}");


                Console.Write("Enter the new genre: ");
                filmGenre.FilmsGenres = Console.ReadLine();

                try
                {
                    filmGenreBusiness.UpdateFilmGenre(filmGenre);
                    Console.WriteLine("Film genre updated successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating film genre: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Film genre not found");
            }
        }

        private void GetFilmGenreInformation()
        {
            Console.Write("Enter the film genre's ID: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                return;
            }

            FilmsGenre filmGenre = filmGenreBusiness.GetFilmGenreById(id);
            if (filmGenre != null)
            {
                Console.WriteLine($"{filmGenre.Id} {filmGenre.FilmId} {filmGenre.FilmsGenres}");
            }
            else
            {
                Console.WriteLine("Film genre not found");
            }
        }
    }
}
