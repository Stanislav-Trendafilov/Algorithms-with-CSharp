using System;

namespace _03._Longest_Com_Sub
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string first = Console.ReadLine();
            string second = Console.ReadLine();

            int count = 0;

            if(first==" "||second==" ")
            {
                Console.WriteLine(1);
                return;
            }
            int ind = 0;
            for (int i = 0; i < first.Length; i++)
            {
                for (int j = ind; j < second.Length; j++)
                {
                    if (first[i] == second[j])
                    {
                        ind = j+1;
                        count++;
                        break;
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}
