using System;
using System.Linq;

namespace _04._Variations_with_Repetition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] elements = Console.ReadLine()
                .Split()
                .Select(char.Parse)
                .ToArray();

            int n = int.Parse(Console.ReadLine());

            variations = new char[n];

            GenerateVariations(elements, 0, n);

        }
        private static char[] variations;
        private static void GenerateVariations(char[] elements, int ind, int n)
        {
            if (ind >= n)
            {
                Console.WriteLine(string.Join(" ", variations));
                return;
            }
            for (int i = 0; i < elements.Length; i++)
            {
                variations[ind] = elements[i];
                GenerateVariations(elements, ind + 1, n);
            }
        }
    }
}
