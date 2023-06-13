using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace _05._PathsInLabyrinth
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            char[,] arr = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string rowData = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    arr[row, col] = rowData[col];
                }
            }

            FindPaths(arr, 0, 0, new List<string>(), string.Empty);
        }

        private static void FindPaths(char[,] arr, int row, int col, List<string> directions, string direction)
        {
            if (row < 0 || row >= arr.GetLength(0) || col < 0 || col >= arr.GetLength(1))
            {
                return;
            }
            if (arr[row, col] == '*' || arr[row, col] == 'v')
            {
                return;
            }

            directions.Add(direction);
            if (arr[row, col] == 'e')
            {
                Console.WriteLine(string.Join(string.Empty, directions));
                PrintMatrix(arr);
                directions.RemoveAt(directions.Count - 1);
                return;
            }
            arr[row, col] = 'v';


            FindPaths(arr, row - 1, col, directions, "U"); //UP
            FindPaths(arr, row + 1, col, directions, "D"); //Down
            FindPaths(arr, row, col - 1, directions, "L"); //Left
            FindPaths(arr, row, col + 1, directions, "R"); //Right

            arr[row, col] = '-';
            directions.RemoveAt(directions.Count - 1);
        }
        private static void PrintMatrix(char[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }

}
