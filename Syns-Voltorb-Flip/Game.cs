using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syns_Voltorb_Flip
{
    public class Game
    {
        /* Grid:
         * [] [] [] [] []
         * [] [] [] [] []
         * [] [] [] [] []
         * [] [] [] [] []
         * [] [] [] [] []
         */
        int[,] grid;
        int score;
        int num2s;
        int num3s;
        int turned2s;
        int turned3s;
        int[] rowPointSums;
        int[] colPointSums;
        VoltorbFlipForm vff;

        public Game(VoltorbFlipForm vff)
        {
            this.vff = vff;
        }

        public void start()
        {
            grid = new int[5, 5];
            score = 0;
            num2s = 0;
            num3s = 0;
            turned2s = 0;
            turned3s = 0;
            rowPointSums = new int[5] { 0, 0, 0, 0, 0 };
            colPointSums = new int[5] { 0, 0, 0, 0, 0 };
            generateGrid();

            debugPrintGrid();
        }

        // Resets the board for a new game after winning or losing a game
        public void resetBoard()
        {

        }

        // Creates the 2D array representing the on-screen grid. Each coordinate holds a value representing a 1, 2, 3, or Voltorb.
        public void generateGrid()
        {
            Random rand = new Random();

            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    int val = rand.Next(4);
                    grid[row, col] = val; // Fills the coordinate with a random int from 0 to 3. 0 = Voltorb
                    colPointSums[col] += val; // Adds the number on the current tile to the sum of the points on the current column
                    rowPointSums[row] += grid[row, col]; // Adds the number on the current tile to the sum of the points on the current row

                    // Adds up the total number of 2 and 3 tiles, used for checking the win condition.
                    if (val == 2)
                    {
                        num2s++;
                    } else if (val == 3)
                    {
                        num3s++;
                    }
                }
            }
            vff.updatePointSums(rowPointSums, colPointSums);
        }

        public int checkTile(int row, int col)
        {
            int tileVal = grid[row, col];

            if (tileVal != 0)
            {
                if (score == 0)
                {
                    score = tileVal;
                } else
                {
                    score *= tileVal;

                    if (tileVal == 2)
                    {
                        turned2s++;
                    } else if (tileVal == 3)
                    {
                        turned3s++;
                    }
                    checkWin();
                }
            } else
            {
                gameOver();
            }

            Console.WriteLine("Score: " + score);
            return grid[row, col];
        }

        public void checkWin()
        {
            if (turned2s == num2s && turned3s == num3s)
            {
                win();
            }
        }

        public void win()
        {
            Console.WriteLine("Win");
        }

        public void gameOver()
        {
            Console.WriteLine("Game over");
           //start();
        }

        // Print the point sums for each row and column for debuggings purposes
        public void debugPrintRowColSums()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Row " + i + " = " + rowPointSums[i]);
            }

            Console.WriteLine();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Col " + i + " = " + colPointSums[i]);
            }
        }

        // Prints the grid to the console for debugging purposes
        public void debugPrintGrid()
        {
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    Console.Write("[" + grid[row, col] + "] ");
                }
                Console.WriteLine();
            }
        }

    }
}
