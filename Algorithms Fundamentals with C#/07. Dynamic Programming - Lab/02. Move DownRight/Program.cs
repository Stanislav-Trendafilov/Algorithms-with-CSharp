using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Move_DownRight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            int[,] matrix = new int[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                int[] rowData = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                for (int c = 0; c < cols; c++)
                {
                    matrix[r, c] = rowData[c];
                }
            }

            int[,] dp = new int[rows, cols];
            dp[0, 0] = matrix[0, 0];

            for (int c = 1; c < cols; c++)
            {
                dp[0, c] = dp[0, c - 1] + matrix[0, c];
            }

            for (int r = 1; r < rows; r++)
            {
                dp[r, 0] = dp[r - 1, 0] + matrix[r, 0];
            }

            for (int r = 1; r < rows; r++)
            {
                for (int c = 1; c < cols; c++)
                {
                    int upper = dp[r - 1, c];
                    int left = dp[r, c - 1];

                    dp[r, c] = Math.Max(upper, left) + matrix[r, c];
                }
            }

            var row = rows - 1;
            var col = cols - 1;

            Stack<string> stack = new Stack<string>();
            while (row > 0 || col > 0)
            {

                stack.Push($"[{row}, {col}]");
                if (row == 0)
                {
                    col -= 1;
                }
                else if (col == 0)
                {
                    row -= 1;
                }
                else
                {
                    var upper = dp[row - 1, col];
                    var left = dp[row, col - 1];

                    if (upper > left)
                    {
                        row -= 1;
                    }
                    else
                    {
                        col -= 1;
                    }
                }
            }
            stack.Push($"[0, 0]");
            while (stack.Count > 0)
            {
                Console.Write(stack.Pop()+" ");
            }
        }
    }
}
