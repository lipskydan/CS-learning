using System;

namespace Udemy_Unit3__tasks
{
    public static class Unit3
    {

        // Числа Фибоначчи
        public static void FibonacciNumber(int size)
        {
            int[] numbers = new int[size];
            
            for(int i=0; i<size; i++)
            {
                if (i == 0 || i == 1) numbers[i] = 1;
                else
                {
                    numbers[i] = numbers[i-1] + numbers[i-2];
                }
            }

            Console.Write("Result: ");
            
            foreach (int el in numbers){
                Console.Write($"{el} ");
            }
        }


        /*
        Запросить у пользователя не более 10 целых положительных чисел. 
        Пользователь может прекратить приём чисел, введя 0.
        После прекращения приёма целых чисел (это происходит в случае если было введено 10 чисел, 
        либо пользователь ввёл 0, чтобы не вводить все 10) подсчитать среднее значение целых положительных 
        чисел кратных трём и вывести на консоль.
        */
        public static void AverageValue()
        {
            int[] numbers = new int[10];
            int counter = 0;

            while(counter < 10)
            {
                Console.Write("Write el = ");
                int el = int.Parse(Console.ReadLine());
                numbers[counter] = el;
                counter++;

                if(el == 0) break;
            }

            int sum = 0;
            counter = 0;

            foreach (int number in numbers)
            {
                if (number > 0 && number%3 == 0)
                {
                    sum += number;
                    counter++;
                }
            }

            Console.WriteLine($"Average = {(double)sum/counter}");
        }

        /*
        Факториалом числа является произведение этого числа на все предшествующие этому числу числа (кроме 0). 
        Факториал в математике записывается через восклицательный знак. Например 5! = 5*4*3*2*1 = 120. 
        Особые случаи: 0! = 1. 1! = 1.
        */
        public static long CountFactorial(int number)
        {
            if (number == 0)  return 1;
            return CountFactorial(number-1) * number;
        }

        /*
        Предположим, что логин\пароль для входа в систему: johnsilver\qwerty.
        Запросить у пользователя логин и пароль. Дать пользователю только три попытки 
        для ввода корректной пары логин\пароль. Если пользователь произвёл корректный ввод, 
        вывести на консоль: "Enter the System" и прекратить запрос логина\пароля. 
        Если пользователь ошибся трижды - вывести "The number of available tries have been exceeded" 
        и прекратить запрос пары логин\пароль.
        */
        public static void ThreeAttemptsToAuthenticate()
        {
            int attempts = 4;
            bool successAuth = false;

            string realLogin = "johnsilver";
            string realPassword = "qwerty";

            while(attempts != 0 || successAuth)
            {
                Console.Write("Please, input login: ");
                string login = Console.ReadLine();

                Console.Write("Please, input password: ");
                string password = Console.ReadLine();

                if (login != realLogin || password != realPassword)
                {
                    attempts--;
                    if(attempts!= 0)Console.WriteLine($"Try again, you have {attempts} attempts");
                    else Console.WriteLine("The number of available tries have been exceeded");
                }else
                {
                    Console.WriteLine("Enter the System");
                    break;
                }
            }
        }
    }
}