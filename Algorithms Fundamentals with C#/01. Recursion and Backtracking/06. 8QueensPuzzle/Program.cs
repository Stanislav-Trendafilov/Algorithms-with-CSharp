using System;
using System.Collections.Generic;

namespace _06._8QueensPuzzle
{
    internal class Program
    {
        private static HashSet<int> queensRows = new HashSet<int>();
        private static HashSet<int> queensCols = new HashSet<int>();
        private static HashSet<int> queensLeftDiagonals = new HashSet<int>();
        private static HashSet<int> queensRightDiagonals = new HashSet<int>();
        static void Main(string[] args)
        {
            int[,]board=new int[8,8];

            Find8Quenns(board, 0);
        }

        private static void Find8Quenns(int[,] board, int row)
        {
          

            if(row>=board.GetLength(0))
            {
                PrintMatrix(board);
                return;

            }
            for (int col = 0; col < board.GetLength(1); col++)
            {
                if(!queensRows.Contains(row)&&!queensCols.Contains(col)&&!queensLeftDiagonals.Contains(row-col)&&!queensRightDiagonals.Contains(row+col))
                {
                    queensRows.Add(row);
                    queensCols.Add(col);
                    queensLeftDiagonals.Add(row-col);
                    queensRightDiagonals.Add(row+col);

                    board[row, col] = 1;

                    Find8Quenns(board, row + 1);

                    queensRows.Remove(row);
                    queensCols.Remove(col);
                    queensLeftDiagonals.Remove(row - col);
                    queensRightDiagonals.Remove(row + col);
                    board[row, col] = 0;

                }
            }
        }

        private static void PrintMatrix(int[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row,col]==1)
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
