using System;
using System.Linq;

namespace Strings_Mashup
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text=Console.ReadLine();
            char[]elements= text
                .ToCharArray()
                .OrderBy(x => x)
                .ToArray();

            int n=int.Parse(Console.ReadLine());
            combinations=new char[n];

            Permutations(elements, 0,0);
        }

        private static char[] combinations;
        private static void Permutations(char[] elements, int ind, int startInd)
        {
            if(ind>=combinations.Length)
            {
                Console.WriteLine(string.Join("",combinations));
                return;
            }
            for (int i = startInd; i < elements.Length; i++)
            {
                combinations[ind] = elements[i];
                Permutations(elements, ind+1, i);
            }
        }
    }
}
