using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace _03._Shortest_Path
{
    internal class Program
    {
        private static List<int>[] graph;
        private static bool[] used;
        private static int[] parent;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int e = int.Parse(Console.ReadLine());

            graph= new List<int>[n+1];
            used= new bool[n+1];

            parent= new int[n+1];
            Array.Fill(parent, -1); 

            for (int node = 0; node < graph.Length; node++)
            {
                graph[node] = new List<int>();
            }

            for (int i = 0; i < e; i++)
            {
                var edge = Console.ReadLine()
                 .Split(' ')
                 .Select(int.Parse)
                 .ToArray();
                int firstNode = edge[0];
                int secondNode = edge[1];

                graph[firstNode].Add(secondNode);
                graph[secondNode].Add(firstNode);
            }

            int start=int.Parse(Console.ReadLine());
            int destination=int.Parse(Console.ReadLine());

            BFS(start,destination);
        }

        private static void BFS(int start,int destination)
        {
            var queue = new Queue<int>();
            queue.Enqueue(start);

            used[start] = true;

            while(queue.Count > 0 )
            {
                var node= queue.Dequeue();

                if(node==destination)
                {
                    List<int> path = new List<int>();

                    int ind = destination;
                    while(ind!=-1)
                    {
                        path.Add(ind);
                        ind = parent[ind]; 
                    }
                    Console.WriteLine($"Shortest path length is: {path.Count-1}");
                    for (int i = path.Count - 1; i >= 0; i--)
                    {
                        Console.Write(path[i]+" ");
                    }
                    break;
                }
      
                foreach (var child in graph[node])
                {
                    if (!used[child])
                    {
                        parent[child] = node;
                        used[child]=true;
                        queue.Enqueue(child);
                    }
                }
            }
        }
    }
}
