using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05._Break_Cycles
{
    public class Edge
    {
        public Edge(string first, string second)
        {
            First = first;
            Second = second;
        }

        public string First { get; set; }
        public string Second { get; set; }
        public override string ToString()
        {
            return $"{First} {Second}";
        }
    }

    internal class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static List<Edge> edges;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            graph = new Dictionary<string, List<string>>();
            edges = new List<Edge>();

            HashSet<string> reversedEdges= new HashSet<string>();


            for (int i = 0; i < n; i++)
            {
                var nodeAndChildren = Console.ReadLine().Split(" -> ");
                var node = nodeAndChildren[0];

                var children = nodeAndChildren[1].Split().ToList();

                graph[node] = children;

                foreach (var child in children)
                {
                    edges.Add(new Edge(node, child));
                }
            }

            edges = edges
                .OrderBy(e => e.First)
                .ThenBy(e => e.Second)
                .ToList();
      
            StringBuilder sb= new StringBuilder();
            int count = 0;

            foreach (var edge in edges)
            {
                if(reversedEdges.Contains(edge.ToString()))
                {
                    continue;
                }
                graph[edge.First].Remove(edge.Second);
                graph[edge.Second].Remove(edge.First);

                if (BFS(edge.First, edge.Second))
                {
                    sb.AppendLine($"{edge.First} - {edge.Second}");
                    reversedEdges.Add($"{edge.Second} {edge.First}");
                    count++;
                }
                else
                {
                    graph[edge.First].Add(edge.Second);
                    graph[edge.Second].Add(edge.First);
                }
            }
            Console.WriteLine($"Edges to remove: {count}");
            Console.WriteLine(sb.ToString());
        }

        private static bool BFS(string start, string destination)
        {
            var queue = new Queue<string>();
            queue.Enqueue(start);

            var visited = new HashSet<string> { start };

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if(node==destination)
                {
                    return true;
                }

                foreach (var child in graph[node])
                {
                    if (visited.Contains(child))
                    {
                        continue;
                    }
                    visited.Add(child);
                    queue.Enqueue(child);
                }

            }

            return false;
        }
    }
}
