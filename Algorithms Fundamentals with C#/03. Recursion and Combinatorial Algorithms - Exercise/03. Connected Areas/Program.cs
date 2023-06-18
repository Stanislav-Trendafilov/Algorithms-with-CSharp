using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Connected_Areas
{
    internal class Program
    {
        private static char[,] arr;
        private static int size;
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            arr = new char[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                string dataRow = Console.ReadLine();
                for (int c = 0; c < cols; c++)
                {
                    arr[r, c] = dataRow[c];
                }
            }

            //List which holds all existing areas

            List<Area> areas = new List<Area>();

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    size = 0;
                    ExploreArea(r, c);
                    areas.Add(new Area(r, c, size));
                }
            }
            List<Area> sortedAreas = areas.Where(x => x.Size > 0)
                .OrderByDescending(x => x.Size)
                .ThenBy(x => x.Row)
                .ThenBy(x => x.Col)
                .ToList();

            Console.WriteLine($"Total areas found: {sortedAreas.Count}");
            for (int i = 0; i < sortedAreas.Count; i++)
            {
                Area currentArea = sortedAreas[i];
                Console.WriteLine($"Area #{i + 1} at ({currentArea.Row}, {currentArea.Col}), size: {currentArea.Size}");
            }
        }

        private static void ExploreArea(int row, int col)
        {
            if (IsOutside(row, col) || IsBoundary(row, col) || IsVisited(row, col))
            {
                return;
            }

            size += 1;
            arr[row, col] = 'v';

            ExploreArea(row - 1, col);
            ExploreArea(row + 1, col);
            ExploreArea(row, col - 1);
            ExploreArea(row, col + 1);
        }
        private class Area
        {
            public Area(int row, int col, int size)
            {
                Row = row;
                Col = col;
                Size = size;
            }

            public int Row { get; set; }

            public int Col { get; set; }

            public int Size { get; set; }

        }
        private static bool IsVisited(int row, int col)
        {
            return arr[row, col] == 'v';

        }

        private static bool IsBoundary(int row, int col)
        {
            return arr[row, col] == '*';

        }

        private static bool IsOutside(int row, int col)
        {
            if (row < 0 || row >= arr.GetLength(0) || col < 0 || col >= arr.GetLength(1))
            {
                return true;
            }
            return false;
        }
    }
}
