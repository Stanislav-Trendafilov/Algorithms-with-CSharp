using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Topological_Sorting
{
    internal class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static Dictionary<string, int> dependencies;
        private static List<string> sorted;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            graph = ReadGrapg(n);

            dependencies = ExtractDependenices(graph);

            sorted = new List<string>();

            while (dependencies.Count > 0)
            {
                var nodeToRemove = dependencies.FirstOrDefault(d => d.Value == 0).Key;

                if (nodeToRemove == null)
                {
                    break;
                }
                dependencies.Remove(nodeToRemove);
                sorted.Add(nodeToRemove);


                foreach (var child in graph[nodeToRemove])
                {
                    dependencies[child]-=1;
                }

            }
            if (dependencies.Count == 0)
            {
                Console.WriteLine("Topological sorting: " + string.Join(", ", sorted));
            }
            else
            {
                Console.WriteLine("Invalid topological sorting");
            }

        }

        private static Dictionary<string, int> ExtractDependenices(Dictionary<string, List<string>> graph)
        {
            var result = new Dictionary<string, int>();

            foreach (var kvp in graph)
            {
                var node = kvp.Key;
                var children = kvp.Value;

                if (!result.ContainsKey(node))
                {
                    result[node] = 0;
                }
                foreach (var child in children)
                {
                    if (!result.ContainsKey(child))
                    {
                        result[child] = 0;
                    }
                    result[child]++;
                }
            }

            return result;
        }

        private static Dictionary<string, List<string>> ReadGrapg(int n)
        {
            var result = new Dictionary<string, List<string>>();
            for (int node = 0; node < n; node++)
            {
                string line = Console.ReadLine();

                string[] parts = line
                   .Split("->", StringSplitOptions.RemoveEmptyEntries)
                   .Select(e => e.Trim())
                   .ToArray();

                string key = parts[0];

                if (parts.Length == 1)
                {
                    result[key] = new List<string>();
                }
                else
                {
                    List<string> children = parts[1].Split(", ").ToList();

                    result[key] = children;
                }
            }
            return result;
        }
    }
}
