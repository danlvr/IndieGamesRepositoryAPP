using System;
using System.Linq;
using IndieGamesRepositoryAPP.Classes;
using IndieGamesRepositoryAPP.Enum;
using static System.Console;


namespace IndieGamesRepositoryAPP
{
    internal static class Program
    {
        private static readonly GamesRepository GamesRepository = new GamesRepository();

        private static void Main()
        {
            var userChoice = GetUserChoice();

            while (userChoice.ToUpper() != "X") 
            {
                switch (userChoice)
                {
                    case "1":
                        ListGames();
                        break;
                    case "2":
                        CreateGame();
                        break;
                    case "3":
                        UpdateGame();
                        break;
                    case "4":
                        DeleteGame();
                        break;
                    case "5":
                        ViewGame();
                        break;
                    case "C":
                        Clear();
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                
                userChoice = GetUserChoice();
            }
            
            WriteLine("Thanks for using this app.");
            ReadLine();
        }
        private static string GetUserChoice()
        {
            WriteLine();
            WriteLine("Welcome to the Indie Games Repository");
            WriteLine("Choose an option:");
            
            WriteLine("1- List games");
            WriteLine("2- Insert new game");
            WriteLine("3- Update game");
            WriteLine("4- Delete game");
            WriteLine("5- View game");
            WriteLine("C- Clean screen");
            WriteLine("X- Exit");
            WriteLine();

            var userChoice = ReadLine()?.ToUpper();
            WriteLine();
            return userChoice;
        }
        private static void ListGames()
        {
            WriteLine("List games");

            var list = GamesRepository.List();

            if (list.Count == 0)
            {
                WriteLine("No registered games.");
                return;
            }

            foreach (var game in from game in list let deleted = game.ReturnIsDeleted() where !deleted select game)
            {
                WriteLine("#ID {0}: - {1}", game.ReturnId(), game.ReturnTitle());
            }
        }
        private static void CreateGame()
        {
            WriteLine("Insert new game");

            foreach (int number in System.Enum.GetValues(typeof(Genre)))
            {
                WriteLine("{0} - {1}", number, System.Enum.GetName(typeof(Genre), number));
            }
            
            WriteLine("Enter the Genre among the options above: ");
            var genreInput = int.Parse(ReadLine() ?? throw new ArgumentOutOfRangeException());
            
            WriteLine("Enter the game Title: ");
            var titleInput = ReadLine();
            
            WriteLine("Enter the year the game Released: ");
            var releaseDateInput = int.Parse(ReadLine() ?? throw new ArgumentOutOfRangeException());
            
            WriteLine("Enter the game summary: ");
            var summaryInput = ReadLine();

            var newGame = new Games(id: GamesRepository.NextId(),
                genre: (Genre)genreInput,
                title: titleInput,
                releaseDate: releaseDateInput,
                summary: summaryInput);
            
            GamesRepository.Create(newGame);
        }
        private static void UpdateGame()
        {
            Write("Enter the game id to update: ");
            var gameId = int.Parse(ReadLine() ?? throw new ArgumentOutOfRangeException());
            
            foreach (int number in System.Enum.GetValues(typeof(Genre)))
            {
                WriteLine("{0} - {1}", number, System.Enum.GetName(typeof(Genre), number));
            }
            
            WriteLine("Enter the Genre among the options above: ");
            var genreInput = int.Parse(ReadLine() ?? throw new ArgumentOutOfRangeException());
            
            WriteLine("Enter the game Title: ");
            var titleInput = ReadLine();
            
            WriteLine("Enter the year the game Released: ");
            var releaseDateInput = int.Parse(ReadLine() ?? throw new ArgumentOutOfRangeException());
            
            WriteLine("Enter the game summary: ");
            var summaryInput = ReadLine();

            var updatedGame = new Games(id: gameId,
                genre: (Genre)genreInput,
                title: titleInput,
                releaseDate: releaseDateInput,
                summary: summaryInput);
            
            GamesRepository.Update(gameId, updatedGame);
        }
        
        private static void DeleteGame()
        {
            Write("Enter the game id to delete: ");
            var gameId = int.Parse(ReadLine() ?? throw new ArgumentOutOfRangeException());

            GamesRepository.Delete(gameId);
        }
        private static void ViewGame()
        {
            Write("Enter the game id to view information: ");
            var gameId = int.Parse(ReadLine() ?? throw new ArgumentOutOfRangeException());
            var game = GamesRepository.ReadById(gameId);

            WriteLine(game);
        }
    }
}