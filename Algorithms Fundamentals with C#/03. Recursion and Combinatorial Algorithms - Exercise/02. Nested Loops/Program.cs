using System;

namespace _02._Nested_Loops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            permutations = new int[n];
            Permutations(n, 0);
        }

        public static int[] permutations;
        private static void Permutations(int n, int ind)
        {
            if (ind >= n)
            {
                Console.WriteLine(string.Join(" ", permutations));
                return;
            }
            for (int i = 0; i < n; i++)
            {
                permutations[ind] = i + 1;

                Permutations(n, ind + 1);

            }
        }
    }
}
