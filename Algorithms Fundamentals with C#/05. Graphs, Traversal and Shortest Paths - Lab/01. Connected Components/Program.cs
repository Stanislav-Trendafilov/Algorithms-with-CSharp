using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Connected_Components
{
    internal class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;
        static void Main(string[] args)
        {
             int n=int.Parse(Console.ReadLine());

            graph = new List<int>[n];
            visited=new bool[n];

            for (int node = 0; node < n; node++)
            {
                string line=Console.ReadLine();

                if (string.IsNullOrEmpty(line))
                {
                    graph[node] = new List<int>();
                }
                else
                {
                    List<int> children=line
                        .Split(" ")
                        .Select(int.Parse)
                        .ToList();

                    graph[node] = children;
                }
            }

            for (int node = 0; node < n; node++)
            {
                List<int> component=new List<int>();
                DFS(node, component);

                if(component.Count > 0)
                {
                    Console.WriteLine($"Connected component: "+string.Join(" ",component));
                }

            }

        }

        private static void DFS(int node, List<int> component)
        {
            if (visited[node])
            {
                return;
            }
            visited[node]=true;

            foreach (var child in graph[node])
            {
                DFS(child, component);
            }

            component.Add(node);
        }
    }
}
