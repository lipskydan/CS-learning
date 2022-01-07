using System;

/*
ДЗ "Угадай число"
Разработать игру "угадай число".

Смысл игры.

Один из игроков загадывает число от 0 до 100 (по умолчанию), а второй пытается угадать за лимитированное число попыток (5 по умолчанию). 
Когда второй игрок делает предположение о загаданном числе, первый игрок сообщает о том угадано ли число, меньше ли оно загаданного, или больше. 
Если угадано - игра завершена. Если меньше или больше загаданного, то второй игрок сужает область поиска и продолжает пытаться угадывать. 
Так происходит до тех пор пока либо число не угадано, либо исчерпано кол-во попыток.

Загадывать может как человек, так и машина. Соответственно и угадывать может как человек, так и машина. Это значит, что надо реализовать два режима игры: 
когда загадывает машина и когда загадывает человек.

Если загадывает человек, а угадывает машина, то нужно сделать так, чтобы машина пыталсь угадать число, используя алгоритм бинарного поиска.

Пример бинарного поиска загаданного числа:
загадано число 18, при условии, что число загадывалось в диапазоне от 0 до 100. Игрок каждый раз берёт середину, т.е. на первой попытке предполагает число 50. 
Первый игрок говорит, что загаданное число меньше. Значит число лежит между 0 и 50. Тогда второй игрок снова делит диапазон на 2 и предполагает 25. 
Первый игрок говорит, что загаднное число меньше. Значит число между 0 и 25. Тогда второй игрок снова делит диапазон на 2 и предполагает 12 
(дробную часть мы просто срезаем). Первый игрок говорит, что загаданное число больше. Значит число лежит в диапазоне между 12 и 25. 
Второй игрок делить диапазон на два и предполагает 18. Первый игрок говорит, что число угадано. Игра завершена.

На каждой попытке , благодаря так стратегии, диапазон поиска сужается в два раза. Это и есть суть бинарного поиска. 
В конце игры выводится информация о том достигнута ли победа или нет. Конечно же, будет необходимо реализовать диалог между игроками.
*/

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