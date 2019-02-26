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
        VoltorbFlipForm vff;

        public void start()
        {
            vff = new VoltorbFlipForm();
            grid = new int[5, 5];
            score = 0;
            num2s = 0;
            num3s = 0;
            turned2s = 0;
            turned3s = 0;
            generateGrid();
            debugPrintGrid();
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
                    grid[row, col] = val; // fills the coordinate with a random int from 0 to 3. 0 = Voltorb
                    
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
        }

        public int checkTile(int row, int col)
        {
            int tileVal = grid[row, col];

            if (tileVal != 0)
            {
                if (score == 0 && tileVal == 1)
                {
                    score = 1;
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

        }

        public void gameOver()
        {

        }

        // Prints the grid to the console for debugging purposes.
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
