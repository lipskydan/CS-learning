using System;

namespace Udemy_Unit8__tasks
{
    class Gamer
    {
        public string Name {get; set;}

        private string xorO;
        public string XorO 
        {
            get
            {
                return xorO;
            }

            set
            {
                if (value == "X" || value == "O") {xorO = value;}
                else
                {
                    Console.WriteLine($"Gamer cannot choose {value}, it will change to X");
                    xorO = "X";
                }
            }
        }

        public Gamer(string name, string XorO)
        {
            Name = name;
            this.XorO = XorO;
        }
    }
    class TicTacToe
    {
        string[,] playAria = new string[3, 3] { {"-","-","-"},
                                                {"-","-","-"},
                                                {"-","-","-"}};

        Gamer gamer1;
        Gamer gamer2;
        public TicTacToe(Gamer gamer1, Gamer gamer2)
        {
            this.gamer1 = gamer1;
            this.gamer2 = gamer2;
        }

        public void showPlayAria()
        {
            int rowLength = playAria.GetLength(0);
            int colLength = playAria.GetLength(1);
            
            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("{0} ", playAria[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
                }
        }


        private Gamer[] getPreorityOfGamers(Gamer gamer1, Gamer gamer2)
        {
            if (gamer1.XorO == "X") return new Gamer[] {gamer1, gamer2};
            return new Gamer[] {gamer2, gamer1};
        }

        private bool CheckPlayersPreparationAndSetPriorityOfPlayers(Gamer gamer1, Gamer gamer2, out Gamer fGamer, out Gamer sGamer)
        {
            if(gamer1.XorO == gamer2.XorO)
            {
                Console.WriteLine($"Player {gamer1.Name} is going to play by {gamer1.XorO} and Player {gamer2.Name} is going to play by {gamer2.XorO}, players should have different chars");
                fGamer = null;
                sGamer = null;
                return false;
            }

            fGamer = getPreorityOfGamers(gamer1, gamer2)[0];
            sGamer = getPreorityOfGamers(gamer1, gamer2)[1];
            return true;
        }

        public bool isGameOver()
        {
            int rowLength = playAria.GetLength(0);
            int colLength = playAria.GetLength(1);
            
            // check rows
            for (int i = 0; i < rowLength; i++)
            {
                if((playAria[i, 0] == "X" && playAria[i, 1] == "X" && playAria[i, 2] == "X")
                || (playAria[i, 0] == "O" && playAria[i, 1] == "O" && playAria[i, 2] == "O")) 
                {
                    if(playAria[i, 0] == gamer1.XorO)
                    {
                        Console.WriteLine($"Player {gamer1.Name} WON");
                    }
                    else
                    {
                        Console.WriteLine($"Player {gamer2.Name} WON");
                    }
                    return true;
                }
            }

            // check columns
            for (int j = 0; j < colLength; j++)
            {
                if((playAria[0, j] == "X" && playAria[1, j] == "X" && playAria[2, j] == "X")
                || (playAria[0, j] == "O" && playAria[1, j] == "O" && playAria[2, j] == "O")) 
                {
                    if(playAria[0, j] == gamer1.XorO)
                    {
                        Console.WriteLine($"Player {gamer1.Name} WON");
                    }
                    else
                    {
                        Console.WriteLine($"Player {gamer2.Name} WON");
                    }
                    return true;
                }
            }

            // check diags
            if ((playAria[0, 0] == "X" && playAria[1, 1] == "X" && playAria[2, 2] == "X")
            || (playAria[0, 0] == "O" && playAria[1, 1] == "O" && playAria[2, 2] == "O"))
            {
                if(playAria[0, 0] == gamer1.XorO)
                {
                    Console.WriteLine($"Player {gamer1.Name} WON");
                }
                else
                {
                    Console.WriteLine($"Player {gamer2.Name} WON");
                }
                 
                return true; 
            }

            if ((playAria[0, 2] == "X" && playAria[1, 1] == "X" && playAria[2, 0] == "X")
            || (playAria[0, 2] == "O" && playAria[1, 1] == "O" && playAria[2, 0] == "O")) 
            {
                if(playAria[1, 1] == gamer1.XorO)
                {
                    Console.WriteLine($"Player {gamer1.Name} WON");
                }
                else
                {
                    Console.WriteLine($"Player {gamer2.Name} WON");
                } 
                return true; 
            }

            return false;
        }

        
        private void MakeStep(Gamer gamer)
        {
            Console.WriteLine($"Player {gamer.Name}, put coordinates to choose cell");
            Console.Write($"row = ");
            
            int.TryParse(Console.ReadLine(), out int row);

            while(row > 2 || row < 0)
            {
                Console.Write($"!!! row can not be 2, row = ");
                int.TryParse(Console.ReadLine(), out row);
            }

            Console.Write($"column = ");
            int.TryParse(Console.ReadLine(), out int column);

            while(column > 2 || column < 0)
            {
                Console.Write($"!!! column can not be 2, column = ");
                int.TryParse(Console.ReadLine(), out column);
            }

            while(playAria[row,column] != "-")
            {
                Console.WriteLine($"Coordinates [{row}, {column}] has been already filled");
                Console.WriteLine($"Put another coordinates to choose cell");
                
                Console.Write($"row = ");
                int.TryParse(Console.ReadLine(), out row);
                
                while(row > 2 || row < 0)
                {
                    Console.Write($"!!! row can not be 2, row = ");
                    int.TryParse(Console.ReadLine(), out row);
                }

                Console.Write($"column = ");
                int.TryParse(Console.ReadLine(), out column);

                while(column > 2 || column < 0)
                {
                    Console.Write($"!!! column can not be 2, column = ");
                    int.TryParse(Console.ReadLine(), out column);
                }
            }

            playAria[row,column]= gamer.XorO;
            Console.WriteLine($"Player {gamer.Name}, made a step, coordinates is [{row}, {column}]");
            showPlayAria();
        }

        public void Play()
        {
            bool willContinue = CheckPlayersPreparationAndSetPriorityOfPlayers(gamer1, gamer2, out Gamer fGamer, out Gamer sGamer);

            if(!willContinue) return;

            int counterSteps = 0;

            while(!isGameOver() || counterSteps<8)
            {
                MakeStep(fGamer);
                counterSteps++;
                if(isGameOver()) break;
                MakeStep(sGamer);
                counterSteps++;
            }
            
        }
    }
}