using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            int Wins = 0;
            int Losses = 0;
            int Ties = 0;
            while(true)
            {
                StatusLine(Wins, Losses, Ties);
                int PlayerSelection, ComputerSelection, Winner;
                WriteOutput("NewGame", 0);

                PlayerSelection = ReadInput("");

                if(PlayerSelection == 0)
                {
                    break;
                }

                ComputerSelection = GenerateRandomNumber(1, 4);
                Winner = GetWinner(PlayerSelection, ComputerSelection);

                switch(Winner)
                {
                    case 0:
                        Ties++;
                        break;
                    case 1:
                        Losses++;
                        break;
                    case 2:
                        Wins++;
                        break;
                }

                WriteOutput("PlayGame", 0);
                WriteOutput("ShowPlayerSelection", PlayerSelection);
                WriteOutput("ShowComputerSelection", ComputerSelection);
                WriteOutput("DisplayWinner", Winner);
                Console.ReadKey();

            }//while(true)
        }//Main

        static int ReadInput(string message)
        {
            Console.Write(message);
            return int.Parse(Console.ReadLine());
        }//ReadInput

        static int GenerateRandomNumber(int Value1, int Value2)
        {
            Random rdm = new Random();
            return rdm.Next(Value1, Value2);
        }//GenerteRandomNumber

        static int GetWinner(int Player, int Computer)
        {
            switch(Player)
            {
                case 1:
                    switch(Computer)
                    {
                        case 1:
                            return 0;
                        case 2:
                            return 1;
                        case 3:
                            return 2;
                        default:
                            Console.WriteLine("Bad Computer Case... Bug Squashing Needed.");
                            return 0;
                    }//switch(Computer)
                case 2:
                    switch(Computer)
                    {
                        case 1:
                            return 2;
                        case 2:
                            return 0;
                        case 3:
                            return 1;
                        default:
                            Console.WriteLine("Bad Computer Case... Bug Squashing Needed.");
                            return 0;
                    }//switch(Computer)
                case 3:
                    switch (Computer)
                    {
                        case 1:
                            return 1;
                        case 2:
                            return 2;
                        case 3:
                            return 0;
                        default:
                            Console.WriteLine("Bad Computer Case... Bug Squashing Needed.");
                            return 0;
                    }//switch(Computer)
                default:
                    Console.WriteLine("Bad Player Case... Bug Squashing Needed.");
                    return 0;
            }//switch(Player)
        }//GetWinner

        static void WriteOutput(string output, int flag)
        {
           switch(output)
           {
               case "NewGame":
                   ClearGameSpace();
                   Console.Write("Rock Paper Scissors\n\n1. Rock\n2. Paper\n3. Scissors\n0. Exit Game\n\nEnter Your Selection: ");
                   break;
               case "PlayGame":
                   ClearGameSpace();
                   Console.WriteLine("You:          Computer:\n");
                   Console.Write("Rock!         Rock!");
                   System.Threading.Thread.Sleep(750);
                   ClearLine();
                   Console.Write("Paper!        Paper!");
                   System.Threading.Thread.Sleep(750);
                   ClearLine();
                   Console.Write("Scissors!     Scissors!");
                   System.Threading.Thread.Sleep(750);
                   ClearLine();
                   System.Threading.Thread.Sleep(750);
                   ClearLine();
                   break;
               case "ShowPlayerSelection":
                   switch(flag)
                   {
                       case 1:
                           Console.Write("Rock");
                           break;
                       case 2:
                           Console.Write("Paper");
                           break;
                       case 3:
                           Console.Write("Scissors");
                           break;
                       default:
                           Console.Write("Middle Finger");
                           break;
                   }//switch(flag)
                   break;
               case "ShowComputerSelection":
                   Console.SetCursorPosition(14, Console.CursorTop);
                   switch (flag)
                   {
                       case 1:
                           Console.Write("Rock");
                           break;
                       case 2:
                           Console.Write("Paper");
                           break;
                       case 3:
                           Console.Write("Scissors");
                           break;
                       default:
                           Console.Write("Middle Finger");
                           break;
                   }//switch(flag)
                   Console.Write("\n");
                   break;
               case "DisplayWinner":
                   switch (flag)
                   {
                       case 0:
                           Console.Write("You tied!");
                           break;
                       case 1:
                           Console.Write("You Lost!");
                           break;
                       case 2:
                           Console.Write("You Won!");
                           break;
                   }
                   break;
           }//switch

        }//Menu

        static void ClearGameSpace()
        {
            int GameSpaceHeight = Console.WindowHeight;
            for (int i = 2; i < GameSpaceHeight - 1; i++)
            {
                Console.SetCursorPosition(0, i);
                ClearLine();
            }
            Console.SetCursorPosition(0, 2);
        }

        static void ClearLine()
        {
            int CurrentLine = Console.CursorTop;
            Console.SetCursorPosition(0, CurrentLine);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, CurrentLine);
        }

        static void StatusLine(int Wins, int Losses, int Ties)
        {
            int CurrentPosX = Console.CursorLeft;
            int CurrentPosY = Console.CursorTop;

            Console.SetCursorPosition(0, 0);

            ClearLine();
            Console.Write("Wins: " + Wins + "  Losses: " + Losses + "  Ties: " + Ties);
            Console.SetCursorPosition(CurrentPosX, CurrentPosY);
        }

    }//Program
}//RockPaperScissors
