using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Udemy_Unit8__tasks
{
    class ChessPlayer
    {
        public int Id {get; set;}
        public string FirstName {get; set;}
        public string SecondName {get; set;}
        public string Title {get; set;}
        public string Country {get; set;}
        public int Rating {get; set;}
        public int Games {get; set;}
        public int BirthYear {get; set;}

        public override string ToString()
        {
            return $"Name is {FirstName} {SecondName}, title is {Title}, from {Country}, was born in {BirthYear}";
        }

        private static ChessPlayer ParseOneChessPlayerFromCsv(string line)
        {
            string[] parts = line.Split(';');
            return new ChessPlayer()
            {
                Id = int.Parse(parts[0]),
                FirstName = parts[1].Trim(),
                SecondName = parts[2].Trim(),
                Title = parts[3].Trim(),
                Country = parts[4].Trim(),
                Rating = int.Parse(parts[5]),
                Games = int.Parse(parts[6]),
                BirthYear = int.Parse(parts[7])
            };
        }

        public static List<ChessPlayer> FindPayersFromRussiaAndSortByAge(string file)
        {
            return File.ReadAllLines(file)
                        .Skip(1)
                        .Select(ParseOneChessPlayerFromCsv)
                        .Where(player => player.Country == "RUS")
                        .OrderBy(player => player.BirthYear)
                        .ToList();
        }

        public static void ShowList(List<ChessPlayer> list)
        {
            foreach (var el in list)
            {
                Console.WriteLine(el);
            }
        } 
    }
}