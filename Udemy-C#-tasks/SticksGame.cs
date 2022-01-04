using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Udemy_Unit8__tasks
{
    public enum PlayerOfStickGame
    {
        Human,
        Computer
    }

    public enum GameStatus
    {
        NotStarted,
        InProcess,
        GameOver
    }
    class SticksGame
    {

        public int TotalAmountSticks
        {
            get; private set;
        }
        public int RemainingAmountSticks 
        {
            get; private set;
        }

        public PlayerOfStickGame Turn
        {
            get; private set;
        }

        public GameStatus GameStatus
        {
            get; private set;
        }

        public event EventHandler<int> HumanAction;
        public event Action<int> ComputerAction;
        public event Action<PlayerOfStickGame> EndOfGame;


        public SticksGame(int totalAmountSticks, PlayerOfStickGame whoMakesFirstStep)
        {
            if (totalAmountSticks > 20 || totalAmountSticks < 10)
            {
                throw new ArgumentException("totalAmountSticks should be > 10 AND < 20");
            }

            TotalAmountSticks = totalAmountSticks;
            RemainingAmountSticks = totalAmountSticks;
            Turn = whoMakesFirstStep;
            GameStatus = GameStatus.NotStarted;
        }

        public void HumanTakes(int sticks)
        {
            if(sticks < 1 || sticks > 3)
            {
                throw new ArgumentException("You can take from 1 to 3 sticks");
            }

            if(sticks > RemainingAmountSticks)
            {
                throw new ArgumentException($"Left only {RemainingAmountSticks} sticks, but you want to take {sticks}");
            }

            RemainingAmountSticks -= sticks;
        }

        public void Start()
        {
            if (GameStatus == GameStatus.GameOver)
            {
                RemainingAmountSticks = TotalAmountSticks;
            }

            if (GameStatus == GameStatus.InProcess)
            {
                throw new ArgumentException("Game has already started");
            }

            GameStatus = GameStatus.InProcess;

            while(GameStatus == GameStatus.InProcess)
            {
                if (Turn == PlayerOfStickGame.Human)
                {
                    HumanMakeStep();
                }
                else
                {
                    ComputerMakeStep();
                }

                checkIfGameOverAndStopGame();

                Turn = Turn == PlayerOfStickGame.Human ? PlayerOfStickGame.Computer : PlayerOfStickGame.Human;
            }
        }

        private void checkIfGameOverAndStopGame()
        {
            if(RemainingAmountSticks == 0)
            {
                GameStatus = GameStatus.GameOver;
                if(EndOfGame != null)
                    EndOfGame(Turn == PlayerOfStickGame.Human ? PlayerOfStickGame.Computer : PlayerOfStickGame.Human);
            }
        }

        private void HumanMakeStep()
        {
            if(HumanAction != null) HumanAction(this, RemainingAmountSticks);
        }

        private void ComputerMakeStep()
        {
            int maxNumber = RemainingAmountSticks >= 3 ? 3 : RemainingAmountSticks;
            int sticks = new Random().Next(1, maxNumber);
            RemainingAmountSticks -= sticks;
            if(ComputerAction != null)
            {
                ComputerAction(sticks);
            }
        }
    }
}