using System;
using Udemy_Unit2__tasks;
using Udemy_Unit2__UserProfile;
using Udemy_Unit3__tasks;
using Udemy_Unit5__tasks;
using Udemy_Unit8__tasks;

namespace Udemy_C__tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine($"CountAreaOfTriangle = {Unit2.CountAreaOfTriangle(2.3, 5.4, 5.8)}");
            // UserProfile anton = new UserProfile(firstName: "Anton", secondName: "Vinnik", age: 23, weight: 78, height: 1.85);
            // anton.CountBodyMassIndex();
            // anton.GetInfo();

            // Unit3.AverageValue();

            // int number = 20;
            // Console.WriteLine($"Factorial of {number} = {Unit3.CountFactorial(number)}");

            // Unit3.ThreeAttemptsToAuthenticate();
            
            // Console.WriteLine(RomanNumbers.Parse("XIV"));

            // Console.WriteLine(new Triangle().CalcTriangleSquare(40,20,30.0));
            // Console.WriteLine(new Triangle().CalcTriangleSquare(10,20));

            // Console.WriteLine(new Triangle().CalcTriangleSquare(10,20,50));

        //     Complex c1 = new Complex(1, 1);
        //     Complex c2 = new Complex(1, 2);
 
        //     Complex result = c1.Plus(c2);

        //    result.PrintInfo();

        // GuessNumber guessNumber = new GuessNumber();
        // Computer computer1 = new Computer("Computer1");
        // Computer computer2 = new Computer("Computer2");
        // Human human1 = new Human("Mykola");
        // Human human2 = new Human("Nastia");
        // guessNumber.PlayGame(whoGuessNumber: human1, whoFindNumber: human2);

        
        // TicTacToe ticTacToe = new TicTacToe(gamer1: new Gamer("Danyil", "X"), gamer2: new Gamer("Olga", "O"));
        // ticTacToe.Play();

        // Gallows gallows = new Gallows();
        // gallows.Game();

        SticksGame sticksGame = new SticksGame(10, PlayerOfStickGame.Human);

        sticksGame.ComputerAction += Game_ComputerAction;
        sticksGame.HumanAction += Game_HumanAction;
        sticksGame.EndOfGame += Game_EndOfGame;

        sticksGame.Start();
        }

        public static void Game_EndOfGame(PlayerOfStickGame player)
        {
            Console.WriteLine($"Winner is {player}");
        }

        public static void Game_ComputerAction(int sticks)
        {
            Console.WriteLine($"Computer took {sticks} sticks");
        }

        public static void Game_HumanAction(object sticksGame, int sticks)
        {
            Console.WriteLine($"Remaining sticks = {sticks}");
            Console.Write("Take some sticks: ");

            bool takenCorrectly = false;

            while(!takenCorrectly)
            {
                if(int.TryParse(Console.ReadLine(), out int takenSticks))
                {
                    var game = (SticksGame)sticksGame;
                    
                    try 
                    {
                        game.HumanTakes(takenSticks);
                        takenCorrectly = true;
                    }
                    catch(ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}
