using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace _04._Cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            allCombinations = new string[names.Length];

            positions = new HashSet<int>();

            string command = Console.ReadLine();
            while (command != "generate")
            {
                string[] cmdArg = command.Split(" - ");
                string name = cmdArg[0];
                int position = int.Parse(cmdArg[1]) - 1;

                positions.Add(position);
                allCombinations[position] = name;

                command = Console.ReadLine();
            }
            int countOfOtherGuests = names.Length - positions.Count;

            combinationsGuests = new string[countOfOtherGuests];
            string[] unspecialGuests = new string[countOfOtherGuests];
            used = new bool[countOfOtherGuests];

            int ind = 0;
            for (int i = 0; i < names.Length; i++)
            {
                if (!allCombinations.Contains(names[i]))
                {
                    unspecialGuests[ind++] = names[i];
                }
            }

            GenerateAllPosibleCombinations(unspecialGuests, 0);

        }

        private static void GenerateAllPosibleCombinations(string[] unspecialGuests, int ind)
        {
            if (ind >= unspecialGuests.Length)
            {
                Console.WriteLine(GenerateCombination(combinationsGuests));
                return;
            }
            for (int i = 0; i < unspecialGuests.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    combinationsGuests[ind] = unspecialGuests[i];
                    GenerateAllPosibleCombinations(unspecialGuests, ind + 1);
                    used[i] = false;
                }

            }
        }

        private static string GenerateCombination(string[] combinationsGuests)
        {
            StringBuilder sb=new StringBuilder();
            int ind = 0;
            for (int i = 0; i < allCombinations.Length; i++)
            {
                if (allCombinations[i]!=null)
                {
                    sb.Append(allCombinations[i]+" ");
                }
                else
                {
                    sb.Append(combinationsGuests[ind++]+" ");
                }
            }
            return sb.ToString().TrimEnd();
        }

        private static string[] allCombinations;
        private static string[] combinationsGuests;
        private static bool[] used;
        private static HashSet<int> positions;

    }
}
