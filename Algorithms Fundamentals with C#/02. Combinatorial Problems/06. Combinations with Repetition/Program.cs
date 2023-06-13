using System;
using System.Linq;

namespace _06._Combinations_with_Repetition
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

            combination = new char[n];

            GenerateCombinations(elements, 0, 0, n);

        }
        private static char[] combination;
        private static void GenerateCombinations(char[] elements, int ind, int startInd, int n)
        {
            if (ind >= n)
            {
                Console.WriteLine(string.Join(" ", combination));
                return;
            }
            for (int i = startInd; i < elements.Length; i++)
            {
                combination[ind] = elements[i];
                GenerateCombinations(elements, ind + 1, i , n);
            }
        }
    }
}
