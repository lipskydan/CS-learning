using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/*
ДЗ "Верю-не-верю"
Скачать файл по ссылке: https://1drv.ms/u/s!AqtQeAOHZEjQuKEZv8A5ZbC3cVyiRw?e=UK4qxh

В файле лежат данные в csv формате. Данные предназначены для игры в "верю-не-верю".

Смысл игры:

Комьютер задаёт вопросы или даёт некоторые утверждения человеку, а человек отвечает да\нет или верит он или 
не верит в утверждение. Компьютер берёт вопросы из файла, правильные ответы и пояснения к ответу тоже. 
Можете записать свои данные в файл.

Кол-во ошибок ограничено и по умолчанию равно 2. Компьютер задаёт вопросы из файла и если человек ответил 
на все вопросы, не допустив более максимально разрешённого кол-ва ошибок, то игрок победил, в противном случае 
проиграл.

Если игрок ошибся при ответе, компьютер выводит пояснение к ответу.

Диалог реализуйте в виде, который сочтёте наиболее приемлимым.
*/

namespace Udemy_Unit8__tasks
{
    
    class Quiz
    {
        public string Question {get; private set;}
        public string Answer {get; private set;}
        public string Hint {get; private set;}

        public static Quiz GetDataFromLineOfCsv(string line)
        {
            string[] data = line.Split(';');

            return new Quiz()
            {
                Question = data[0].Trim(),
                Answer = data[1].Trim(),
                Hint = data[2].Trim()
            };
        }

        public static List<Quiz> GetListQuestionAnswerHint(string file)
        {
            return File.ReadAllLines(file)
                       .Select(GetDataFromLineOfCsv)
                       .ToList();
        }
    }

    public enum PlayerOfGameBelieveOrNo
    {
        Human,
        Computer
    }

    public enum GameStatusBelieveOrNo
    {
        NotStarted,
        InProcess,
        GameOver
    }
    class GameBelieveOrNo
    {
        public int Attempts
        {
            get; set;
        }
        public int RemainingAttempts
        {
            get; set;
        }

        public int QuantityOfQuestion
        {
            get; set;
        }

        public int CountOfCorrectAnswers
        {
            get; set;
        }

        public PlayerOfGameBelieveOrNo Turn
        {
            get; set;
        }

        public GameStatusBelieveOrNo GameStatus
        {
            get; set;
        }
        public List<Quiz> listBelieveOrNo;
        public Quiz currBelieveOrNo;
        public event EventHandler<Quiz> HumanAction;
        public event EventHandler<Quiz> ComputerAction;
        public event Action<PlayerOfGameBelieveOrNo> EndOfGame;

        public GameBelieveOrNo(string file, int attempts=2)
        {
            Attempts = attempts;
            RemainingAttempts = attempts;
            Turn = PlayerOfGameBelieveOrNo.Computer;
            listBelieveOrNo = Quiz.GetListQuestionAnswerHint(file);
            QuantityOfQuestion = listBelieveOrNo.Count();
            CountOfCorrectAnswers = 0;
        }
        public void Game()
        {
            if (GameStatus == GameStatusBelieveOrNo.GameOver)
            {
                RemainingAttempts = Attempts;
            }

            if (GameStatus == GameStatusBelieveOrNo.InProcess)
            {
                throw new ArgumentException("Game has already started");
            }

            GameStatus = GameStatusBelieveOrNo.InProcess;

            while(GameStatus == GameStatusBelieveOrNo.InProcess)
            {
                if (Turn == PlayerOfGameBelieveOrNo.Human)
                {
                    HumanMakeStep();
                }
                else
                {
                    ComputerMakeStep();
                }

                checkStopGameIfGameOver();
                SwapTurn();
            }
        }

        private void checkStopGameIfGameOver()
        {
            if(RemainingAttempts == 0 || CountOfCorrectAnswers==QuantityOfQuestion)
            {
                GameStatus = GameStatusBelieveOrNo.GameOver;
                if(EndOfGame != null)
                {
                    EndOfGame(WhoWon());   
                }
            }
        }

         private void HumanMakeStep()
        {
            if(HumanAction != null) HumanAction(this, currBelieveOrNo);
        }

        private void ComputerMakeStep()
        { 
            int random = new Random().Next(0, listBelieveOrNo.Count()-1);
            currBelieveOrNo = listBelieveOrNo[random];
            listBelieveOrNo.Remove(currBelieveOrNo);
            
            if(ComputerAction != null)
            {
                ComputerAction(this, currBelieveOrNo);
            }
        }

        private void SwapTurn()
        {
            Turn = Turn == PlayerOfGameBelieveOrNo.Human ? PlayerOfGameBelieveOrNo.Computer : PlayerOfGameBelieveOrNo.Human;
        }

        private PlayerOfGameBelieveOrNo WhoWon()
        {
            if(RemainingAttempts == 0) return PlayerOfGameBelieveOrNo.Computer;
            return PlayerOfGameBelieveOrNo.Human;
        }

        public static bool IsEmpty<T>(List<T> list)
        {
            if (list == null) return true;
            return list.Count == 0;
        }
    }
}