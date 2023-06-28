using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Road_Reconstruction
{
    internal class Program
    {
        private static Dictionary<int, List<int>> graph;

        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());
            int pairs = int.Parse(Console.ReadLine());

            graph = new Dictionary<int, List<int>>();

            for (int i = 0; i < nodes; i++)
            {
                var nodeAndChildren = Console.ReadLine().Split(":");

                int node = int.Parse(nodeAndChildren[0]);
                if (nodeAndChildren[1] != string.Empty)
                {
                    List<int> children = nodeAndChildren[1]
                        .Split(" ")
                        .Select(int.Parse)
                        .ToList();

                    graph[node] = children;
                }
                else
                {
                    graph[node] = new List<int>();
                }
            }

            for (int i = 0; i < pairs; i++)
            {
                var pair = Console.ReadLine()
                    .Split("-")
                    .Select(int.Parse)
                    .ToArray();

                int start = pair[0];
                int destination = pair[1];

                var steps = BFS(start, destination);


                Console.WriteLine($"{{{start}, {destination}}} -> {steps}");
            }
        }

        private static int BFS(int start, int destination)
        {
            var visited = new HashSet<int>();
            var parent = new Dictionary<int, int>() { { start, -1 } };

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);

            visited.Add(start);

            while (queue.Count > 0)
            {
                int node = queue.Dequeue();

                if (node == destination)
                {

                    return GetSteps(parent, destination);
                }
                foreach (var child in graph[node])
                {
                    if (visited.Contains(child))
                    {
                        continue;
                    }

                    visited.Add(child);
                    queue.Enqueue(child);
                    parent[child] = node;
                }
            }

            return -1;
        }

        private static int GetSteps(Dictionary<int, int> parent, int destination)
        {
            var node = destination;
            int steps = 0;
            while (node != -1)
            {
                node = parent[node];
                steps++;
            }
            return steps - 1;
        }
    }
}
