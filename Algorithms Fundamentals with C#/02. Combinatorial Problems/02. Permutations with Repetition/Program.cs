using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Permutations_with_Repetition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] chars = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();

            used = new bool[chars.Length];

            permutations = new char[chars.Length];

            existingPermutations=new HashSet<string>();

            Permutations(chars, 0);
        }
        private static char[] permutations;
        private static bool[] used;
        private static HashSet<string> existingPermutations;
        private static void Permutations(char[] chars, int index)
        {
            if (index >= chars.Length)
            {
                string currentPermutation= string.Join(" ", permutations);
                if(!existingPermutations.Contains(currentPermutation)) 
                {
                    existingPermutations.Add(currentPermutation);
                    Console.WriteLine(currentPermutation);
                    return;
                }
               
            }
            for (int i = 0; i < chars.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    permutations[index] = chars[i];
                    Permutations(chars, index + 1);
                    used[i] = false;
                }

            }
        }
    }
}
