using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Road_Reconstruction
{
    public class Edge
    {
        public Edge(int first, int second)
        {
            First = first;
            Second = second;
        }

        public int First { get; set; }

        public int Second { get; set; }
    }
    internal class Program
    {
        private static List<int>[] graph;
        private static List<Edge> edges;
        private static bool[] visited;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int e = int.Parse(Console.ReadLine());

            graph= new List<int>[n];
            edges= new List<Edge>();

            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<int>();
            }

            for (int i = 0; i < e; i++)
            {
                var edgeParts=Console.ReadLine()
                    .Split(" - ")
                    .Select(int.Parse)
                    .ToArray();

                int firstNode = edgeParts[0];
                int secondNode = edgeParts[1];

                graph[firstNode].Add(secondNode);
                graph[secondNode].Add(firstNode);

                edges.Add(new Edge(firstNode, secondNode));

            }
            Console.WriteLine("Important streets:");
            foreach (var edge in edges)
            {
                graph[edge.Second].Remove(edge.First);
                graph[edge.First].Remove(edge.Second);

                visited=new bool[graph.Length];

                DFS(0);

                if(visited.Contains(false))
                {
                    Console.WriteLine($"{Math.Min(edge.First,edge.Second)} {Math.Max(edge.First, edge.Second)}");
                }

                graph[edge.Second].Add(edge.First);
                graph[edge.First].Add(edge.Second);
            }
        }

        private static void DFS(int node)
        {
            if (visited[node])
            {
                return;
            }
            visited[node]=true;

            foreach (var child in graph[node])
            {
                DFS(child);
            }
        }
    }
}
