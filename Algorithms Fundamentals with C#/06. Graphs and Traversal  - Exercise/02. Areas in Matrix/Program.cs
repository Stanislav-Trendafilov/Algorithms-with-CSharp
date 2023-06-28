using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;

namespace _02._Areas_in_Matrix
{
    internal class Program
    {
        private static char[,] graph;
        private static bool[,] visited;
        private static Dictionary<char, int> areas;
        static void Main(string[] args)
        {

            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            areas = new Dictionary<char, int>();
            visited = new bool[rows, cols];
            graph = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string rowData = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    graph[row, col] = rowData[col];
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (visited[row, col])
                    {
                        continue;
                    }
                    var nodeValue = graph[row, col];
                    DFS(row, col, nodeValue);


                    if (areas.ContainsKey(nodeValue))
                    {
                        areas[nodeValue]++;
                    }
                    else
                    {
                        areas[nodeValue] = 1;
                    }
                }
            }
            Console.WriteLine($"Areas: {areas.Values.Sum()}");
            foreach (var area in areas.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"Letter '{area.Key}' -> {area.Value}");
            }
        }

        private static void DFS(int row, int col, char nodeValue)
        {
            if (row < 0 || row >= graph.GetLength(0) || col < 0 || col >= graph.GetLength(1))
            {
                return;
            }
            if (visited[row, col])
            {
                return;
            }
            if (graph[row, col] != nodeValue)
            {
                return;
            }

            visited[row, col] = true;

            DFS(row, col - 1, nodeValue);
            DFS(row, col + 1, nodeValue);
            DFS(row - 1, col, nodeValue);
            DFS(row + 1, col, nodeValue);
        }
    }
}
