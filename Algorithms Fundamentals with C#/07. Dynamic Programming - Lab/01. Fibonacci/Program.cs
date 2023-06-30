using System;

namespace _01._Fibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(FindFib(n));
        }

        private static long FindFib(int n)
        {
            long result = 0;

            long firstNum = 0;
            long secondNum = 1;

            for (int i = 2; i <= n; i++)
            {
                result = firstNum + secondNum;

                firstNum = secondNum;
                secondNum = result;
            }

            return result;
        }
    }
}
