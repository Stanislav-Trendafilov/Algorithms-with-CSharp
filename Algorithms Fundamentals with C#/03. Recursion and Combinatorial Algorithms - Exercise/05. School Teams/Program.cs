using System;
using System.Collections.Generic;

namespace _05._School_Teams
{
    internal class Program
    {
        private static List<string> allGirlsComb;
        private static List<string> allBoysComb;
        static void Main(string[] args)
        {
            string[] girls = Console.ReadLine().Split(", ");
            string[] girlComb = new string[3];
            allGirlsComb = new List<string>();


            string[] boys = Console.ReadLine().Split(", ");
            string[] boysComb = new string[2];
            allBoysComb = new List<string>();

            GenComb(0, 0, girls, girlComb, allGirlsComb);
            GenComb(0, 0, boys, boysComb, allBoysComb);

            foreach (var girlCombination in allGirlsComb)
            {
                foreach (var boyCombination in allBoysComb)
                {
                    Console.WriteLine(girlCombination + ", " + boyCombination);
                }
            }


        }

        private static void GenComb(int ind, int start, string[] people, string[] combinations, List<string> allCombinations)
        {
            if (ind >= combinations.Length)
            {
                allCombinations.Add(string.Join(", ", combinations));
                return;
            }
            for (int i = start; i < people.Length; i++)
            {
                combinations[ind] = people[i];
                GenComb(ind + 1, i + 1, people, combinations, allCombinations);
            }
        }
    }
}
