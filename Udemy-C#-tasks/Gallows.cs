using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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
            Console.WriteLine("Computer set hidden word");

            possibleWord = new List<char>();
            for(int i=0; i<hiddenWord.Length; i++){possibleWord.Add('_');}
        }

        public void ShowHiddenWord(){Console.WriteLine($"Hidden word is {HiddenWord}");}

        public void ShowGuessedWord() 
        {
            Console.Write($"Guessed word is");
            foreach(char el in possibleWord){Console.Write($" {el}");}
            Console.WriteLine();
        }

        public void ShowCounterAttempts(){Console.WriteLine($"You have {counterAttempts} attempts");}

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
                counterAttempts--;
            }
                
        }

        public void Game()
        {
            ShowHiddenWord();
            ShowGuessedWord();

            while(counterAttempts > 0)
            {
                Console.Write("Please, input possible letter: ");
                char possibleLetter = Convert.ToChar(Console.Read());
                SetPossibleLetter(possibleLetter);
                ShowGuessedWord();
            }
            
        }

    }
}