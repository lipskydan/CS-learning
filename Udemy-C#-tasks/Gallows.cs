using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Udemy_Unit8__tasks
{
    class Gallows
    {

        readonly String pathToWordsStock = "FileForGallows/WordsStockRus.txt";
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

        public Gallows()
        {
            SetHiddenWord();
            Console.WriteLine("[Gallows:Gallows()] Computer set hidden word");
            possibleWord = new List<char>();
            for(int i=0; i<hiddenWord.Length; i++){possibleWord.Add('_');}
        }

        public void ShowHiddenWord(){Console.WriteLine($"Hidden word is {HiddenWord}");}

        public void ShowGuessedWord() 
        {
            Console.Write($"[Gallows:ShowGuessedWord()] Guessed word is");
            foreach(char el in possibleWord)
            {
                Console.Write($" {el}");
            }
            Console.WriteLine();
        }

        public void SetPossibleLetter(char possibleLetter)
        {
            if(HiddenWord.Contains(possibleLetter))
                for(int i=0; i<HiddenWord.Length; i++)
                    if (HiddenWord[i] == possibleLetter){possibleWord[i] = possibleLetter;}
        }

        public void Game()
        {
            Console.Write("Please, input possible letter: ");
            char possibleLetter = Convert.ToChar(Console.Read());
            SetPossibleLetter(possibleLetter);
        }

    }
}