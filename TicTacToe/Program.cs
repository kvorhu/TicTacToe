using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    //TicTacToe, Console Application
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Press Any key to start a new game! ");
                Console.ReadKey();
                StartGame();
            }
            //Console.ReadKey();
        }

        static void StartGame()
        {
            GameTable game = new GameTable();
            int playerNo = 0;
            string field;
            int moves = 0;
            Console.Clear();
            //game.DisplayTable();
            Console.WriteLine("NEW GAME STARTED");
            game.DisplayTable();
            while (true)
            {
                Console.Write("Player {0}: Choose Your Field! : ", playerNo + 1);
                field = Console.ReadLine();
                bool result =  (playerNo == 0) ? game.PlayOne(field) : game.PlayTwo(field);
                if (!result) { game.ErrorMessage(); }
                else
                {
                    if (game.CheckWin(playerNo, int.Parse(field) ) )
                    {
                        Console.Clear();
                        game.DisplayTable();
                        Console.WriteLine("PLAYER {0} WINS !",playerNo+1);
                        Console.WriteLine("!___________________(*-*)_____________________!");
                        Console.WriteLine("Any Key to Continue =?");
                        Console.ReadKey();
                        break;
                                              
                    }
                    moves++;
                    if (moves == 9)
                    {
                        Console.Clear();
                        game.DisplayTable();
                        Console.WriteLine("It's a draw!");
                        Console.WriteLine("!__________________(~_~)_____________________!");
                        Console.WriteLine("Any Key to Continue =?");
                        Console.ReadKey();
                        break;
                    }
                    playerNo = (playerNo == 0) ? 1 : 0;
                    Console.Clear();
                    game.DisplayTable();
                }
                
            }

        }
    }
}
