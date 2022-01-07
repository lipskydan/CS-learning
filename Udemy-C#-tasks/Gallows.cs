using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

/*
ДЗ "Виселица"
Старая добрая игра "Виселица" (с недобрым названием).
Смысл игры:
Компьютер загадывает любое слово, взятое из словаря (ссылка на словарь прилагается). Человек пытается, называя буквы, угадать слово. 
Если буква есть в слове, компьютер вскрывает отгаданные буквы. Неотгаданные буквы не вскрываются, а выводятся, например, прочерки (дефисы). 
Есть ограниченное кол-во попыток (по умолчанию, максимум 6). Если попытки исчерпаны - человек проиграл, игра завершается и показывается загаданное 
слово и кол-во ошибок допущенных игроком.

Рисовать виселицу в консоли необязательно. Если есть желание - это сделать можно (но огребёте головной боли).

Ссылка на словарь: https://1drv.ms/t/s!AqtQeAOHZEjQuKEXnwI-VtMds9wAug?e=bGvrIR
*/

namespace Udemy_Unit8__tasks
{
    class Gallows
    {

        readonly String pathToWordsStock = "FileForGallows/WordsStockRus.txt";
        private int counterAttempts;
        private String hiddenWord;

        private List<char> possibleWord;
        private String HiddenWord
        {
            get 
            {
               return hiddenWord; 
            }
        }

        private void SetHiddenWord()
        {
            string[] lines = File.ReadAllLines(pathToWordsStock);
            hiddenWord = lines[new Random().Next(0, lines.Length-1)];
        }

        public Gallows(int counterAttempts = 6)
        {
            this.counterAttempts = counterAttempts;

            SetHiddenWord();
            Console.WriteLine($"Computer set hidden word\n");

            possibleWord = new List<char>();
            for(int i=0; i<hiddenWord.Length; i++){possibleWord.Add('_');}
        }

        public void ShowHiddenWord(){Console.WriteLine($"Hidden word is {HiddenWord}\n");}

        public void ShowGuessedWord() 
        {
            Console.Write($"Guessed word is");
            foreach(char el in possibleWord){Console.Write($" {el}");}
            Console.WriteLine("\n");
        }

        public void ShowCounterAttempts(){Console.WriteLine($"You have {counterAttempts} attempts\n");}

        public void SetPossibleLetter(char possibleLetter)
        {
            if(HiddenWord.Contains(possibleLetter))
            {
                for(int i=0; i<HiddenWord.Length; i++)
                {
                    if (HiddenWord[i] == possibleLetter)
                    {
                        possibleWord[i] = possibleLetter;
                    }
                }
            }
            else
            {
                --counterAttempts;
            }
                
        }

        public void Game()
        {
            
            while(true)
            {
                if(counterAttempts == 0 || possibleWord.Contains('_') == false) break;
               
                ShowGuessedWord();
                ShowCounterAttempts();

                Console.Write("Please, input possible letter: ");

                try
                {
                    char possibleLetter = Convert.ToChar(Console.ReadLine());
                    SetPossibleLetter(possibleLetter);
                }
                catch (System.Exception)
                {
                }


                // Console.Write("Please, input possible letter: ");
                // // char.TryParse(Console.ReadLine(), out char possibleLetter);
                // // char possibleLetter = Convert.ToChar(Console.ReadLine());
                // SetPossibleLetter(possibleLetter);
                
                Console.WriteLine("\n");
                
            }

            if(counterAttempts == 0)
            {
                Console.WriteLine("YOU LOST :ь\n");
                 ShowHiddenWord();
            }
            else
            {
                Console.WriteLine("YOU WON :)\n");
                ShowGuessedWord();
                ShowHiddenWord();
            }
            
        }

    }
}