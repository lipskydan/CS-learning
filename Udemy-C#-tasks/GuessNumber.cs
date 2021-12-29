using System;

namespace Udemy_Unit8__tasks
{
    abstract class Player 
    {
        public string Name {get; set;}

    }
    class Human: Player
    {
        public Human(string name) {Name = name;}
    }

    class Computer: Player
    {
        public Computer(string name) {Name = name;}
    }
    class GuessNumber
    {
        private int hiddenNumber;
        public int HiddenNumber 
        {
            get {return hiddenNumber;}
            set
            {
                if(value > 100 || value < 0)
                {
                    Console.WriteLine("HiddenNumber should be between 0 and 100");
                    hiddenNumber = 0;
                }
                hiddenNumber = value;
            }
        }

        public int Tries{get; set;} = 5;

        private int HumanFindNumber(Player human)
        {
            Console.Write($"User {human.Name}, choose your variante of hidden number, please: ");
            int possibleNumber = Convert.ToInt32(Console.ReadLine());
            return possibleNumber;
        }

        private int HumanGuessNumber(Player human)
        {
            Console.Write($"Dear, {human.Name} guess number: ");
            int hiddenNumber = Convert.ToInt32(Console.ReadLine());
            return hiddenNumber;
        }

        
        private void FindNumber(Player whoGuessNumber, Player whoFindNumber)
        {
            int possibleNumber;
            int max = 100;
            int min = 0;

            if(whoFindNumber is Human)
            {
                possibleNumber = HumanFindNumber(whoFindNumber);
            }
            else if(whoFindNumber is Computer)
            {
                possibleNumber = new Random().Next(min,max);
            }
            else
            {
                possibleNumber = -100;
            }

            while(possibleNumber != HiddenNumber && Tries > 1){
                if(possibleNumber > HiddenNumber)
                {
                    Console.WriteLine($"User {whoFindNumber.Name} decided that hiden number is {possibleNumber}, but hidden number is less");
                    if(whoFindNumber is Human) possibleNumber = HumanFindNumber(whoFindNumber);
                    if(whoFindNumber is Computer)
                    {
                        max = possibleNumber;
                        possibleNumber = new Random().Next(min,max);
                    }
                    Tries--;
                }
                else
                {
                    Console.WriteLine($"User {whoFindNumber.Name} decided that hiden number is {possibleNumber}, but hidden number is more");
                    if(whoFindNumber is Human) possibleNumber = HumanFindNumber(whoFindNumber);
                    if(whoFindNumber is Computer)
                    {
                        min = possibleNumber;
                        possibleNumber = new Random().Next(min,max);
                    }
                    Tries--;
                }  
            }
            if(Tries > 1 && possibleNumber==HiddenNumber)
            {
            Console.WriteLine($"User {whoFindNumber.Name} decided that hiden number is {possibleNumber}, it is correct");
            Console.WriteLine($"User {whoFindNumber.Name} WON");
            }
            else
            {
                Console.WriteLine($"User {whoFindNumber.Name} spent all attempts :(");
                Console.WriteLine($"User {whoGuessNumber.Name} WON");
            }
        }

        public void PlayGame(Player whoGuessNumber, Player whoFindNumber)
        {

            if (whoGuessNumber is Computer)
            {
                HiddenNumber = new Random().Next(0,100);
                Console.WriteLine($"User {whoGuessNumber.Name} guessed number");
            }
            else
            {
                HiddenNumber = HumanGuessNumber(whoGuessNumber);
            }

            FindNumber(whoGuessNumber, whoFindNumber);
        }
    }
}