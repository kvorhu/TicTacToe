using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class GameTable
    {
        //variables
        private int[,] table = new int[3, 3];
        private int[,] playerOne = new int[3, 3];
        private int[,] playerTwo = new int[3, 3];

        //Constructor
        public GameTable()
        {
            InitializeTable();
            DisplayTable();
        }

        private void InitializeTable()
        {
            int counter = 1;
            for(int i = 0; i < table.GetLength(0); i++)
            {
               for(int j = 0; j < table.GetLength(1);j++)
                {
                    table[i, j] = counter++;
                    playerOne[i, j] = 0;
                    playerTwo[i, j] = 0; 
                }
            }
        }

        public void DisplayTable()
        {
            //Console.Clear();
            for (int i = 0; i < table.GetLength(0); i++)
            {
                Console.WriteLine("   |   |   ");
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    if (j == table.GetLength(1) - 1)
                    {
                        Console.WriteLine(" {0} ",findEntry(i,j));
                    }
                    else
                    {
                        Console.Write(" {0} |",findEntry(i,j));
                    }

                }
                if (i == table.GetLength(0) - 1)
                {
                    Console.WriteLine("   |   |   ");
                }
                else
                {
                    Console.WriteLine("___|___|___");
                }
            }
        }

        private string findEntry(int i, int j )
        {
            if (playerOne[i,j] == 1 || playerTwo[i,j] == 1)
            {
                return (playerOne[i, j] == 1) ? "X" : "O";
                
            }
            else
            {
                return table[i, j].ToString();
            }
        }

        private bool isValid(int i, int j )
        {
            if (playerOne[i, j] == 1 || playerTwo[i, j] == 1)
            {
                return false;

            }
            return true;
        }

        public bool PlayOne(string input)
        {
            int index = -1;
            if (!(int.TryParse(input, out index)))
            {
                return false;
            }
            else
            {
                if(1 > index || index > 9 )
                {
                    return false;
                }
                int[] indices = new int[2];
                indices = getIndex(index);
                int i = indices[0];
                int j = indices[1];
                if (!isValid(i,j))
                {
                    return false;
                }
                playerOne[i, j] = 1;
                return true;
                
            }
        }

        public bool PlayTwo(string input)
        {
            int index = -1;
            if (!(int.TryParse(input, out index)))
            {
                return false;
            }
            else
            {
                if (1 > index || index > 9)
                {
                    return false;
                }
                int[] indices = new int[2];
                indices = getIndex(index);
                int i = indices[0];
                int j = indices[1];
                if (!isValid(i, j))
                {
                    return false;
                }
                playerTwo[i, j] = 1;
                return true;

            }
        }

        public int[] getIndex(int index)
        {
            int temp = index;
            int i = 0;
            int j = 0;
            while (temp-3 > 0)
            {
                i++;
                temp = temp - 3;
            }
            j = temp-1;
            int[] res = new int[] { i, j };
            return res ;
        }

        //Check if move has resulted in a win
        public bool CheckWin(int player, int field)
        {
            int i, j;
            int[] indices = getIndex(field);
            i = indices[0];
            j = indices[1];
            if (player == 0) //player 1
            {
                if (playerOne[0, 2] == 1 && playerOne[1, 1] == 1 && playerOne[2, 0] == 1) { return true; }

                if (playerOne[0, 0] == 1 && playerOne[1, 1] == 1 && playerOne[2, 2] == 1) { return true; }

                if (i == 1)
                {
                    if(playerOne[i+1,j] == 1 && playerOne[i-1, j] == 1) { return true; }
                    
                    if (playerOne[i, 0] == 1 && playerOne[i, 1] == 1 && playerOne[i, 2] == 1) { return true; }
                    
                    if (j == 1 && playerOne[i,j-1] ==1 && playerOne[i,j+1] == 1) { return true; }
                    
                    return false;
               }
               else
                {
                    if (playerOne[i, 0] == 1 && playerOne[i, 1] == 1 && playerOne[i,2] == 1) { return true; }
                    if(i == 0 && playerOne[i+1,j] == 1 && playerOne[i+2,j] == 1) { return true; }
                    if (i == 2 && playerOne[i - 1, j] == 1 && playerOne[i - 2, j] == 1) { return true; }
                    return false;

                }



            }
            else //player 2
            {
                if (playerTwo[0, 2] == 1 && playerTwo[1, 1] == 1 && playerTwo[2, 0] == 1) { return true; }

                if (playerTwo[0, 0] == 1 && playerTwo[1, 1] == 1 && playerTwo[2, 2] == 1) { return true; }

                if (i == 1)
                {
                    if (playerTwo[i + 1, j] == 1 && playerTwo[i - 1, j] == 1) { return true; }

                    if (playerTwo[i, 0] == 1 && playerTwo[i, 1] == 1 && playerTwo[i, 2] == 1) { return true; }

                    if (j == 1 && playerTwo[i, j - 1] == 1 && playerTwo[i, j + 1] == 1) { return true; }

                    return false;
                }
                else
                {
                    if (playerTwo[i, 0] == 1 && playerTwo[i, 1] == 1 && playerTwo[i, 2] == 1) { return true; }
                    if (i == 0 && playerTwo[i + 1, j] == 1 && playerTwo[i + 2, j] == 1) { return true; }
                    if (i == 2 && playerTwo[i - 1, j] == 1 && playerTwo[i - 2, j] == 1) { return true; }
                    return false;

                }
            }
        }

        public void ErrorMessage()
        {
            Console.WriteLine("Incorrect MOVE, Please Try again....");
        }


    }
}
