using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace _03._Variations_without_Repetition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[]elements=Console.ReadLine()
                .Split()
                .Select(char.Parse)
                .ToArray();

            int n=int.Parse(Console.ReadLine());

            variations=new char[n];
            used = new bool[elements.Length];
            GenerateVariations(elements, 0, n);
            
        }
        private static char[] variations;
        private static bool[] used;
        private static void GenerateVariations(char[] elements, int ind, int n)
        {
            if (ind>=n)
            {
                Console.WriteLine(string.Join(" ", variations));
                return;
            }
            for (int i = 0; i < elements.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    variations[ind] = elements[i];
                    GenerateVariations(elements, ind + 1,n);
                    used[i] = false;
                }
            }
        }
    }
}
