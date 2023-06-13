using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace _01._Permutations_without_Repetition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[]chars=Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();

            used = new bool[chars.Length];
            permutations=new char[chars.Length];

            Permutations(chars,0);
        }
        private static char[] permutations;
        private static bool[] used;
        private static void Permutations(char[] chars, int index)
        {
            if (index >= chars.Length)
            {
                Console.WriteLine(string.Join(" ",permutations));
                return;
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
