using System;

namespace Udemy_Unit2__tasks
{
    static class Unit2
    {
        // Запросить имя пользователя. Вывести Hello, [имя пользователя].
        public static void Task1()
        {
            Console.Write("Input name: ");
            string name = Console.ReadLine();
            Console.WriteLine($"Hello, {name}");
        }

        /*  Запросить у пользователя два целых числа и сохранить в двух переменных. Вывести значения. 
        Обменять значения переменных: например, если в переменной x было записано число 3, а в y число 5,
         сделать так, чтобы в y стало 3, а в x стало 5. Вывести значения после обмена. */
         public static void Task2()
         {
             Console.WriteLine("Input a: ");
             int a = int.Parse(Console.ReadLine());
             Console.WriteLine("Input b: ");
             int b = int.Parse(Console.ReadLine());

             Console.WriteLine($"a = {a}, b = {b}");

             Unit2.MySwap(ref a, ref b);

             Console.WriteLine($"a = {a}, b = {b}");
         }

        /*Запросить у пользователя целое число. Вывести количество цифр числа. 
        Например, в числе 156 - 3 цифры.*/
         public static void Task3()
         {
             Console.Write("Input number: ");
             int number = int.Parse(Console.ReadLine());
             
             Console.WriteLine($"In number {number} - {number.ToString().Length} digits");
         }

         static void MySwap(ref int a, ref int b)
         {
             int tmp = a;
             a = b;
             b = tmp;
         }

         public static double CountAreaOfTriangle(double a, double b, double c)
         {
             double p = CountHalfP(a,b,c);
             return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
         }

         static double CountHalfP(double a, double b, double c) => (a+b+c)/2;
         
    }
}
