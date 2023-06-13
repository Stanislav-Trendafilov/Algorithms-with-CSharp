using System;
using System.Linq;

namespace _01._RecursiveArraySum
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var arr = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(Func(arr, 0));

        }
        static int Func(int[] arr, int count)
        {
            if (count == arr.Length - 1)
            {
                return arr[count];
            }
            return arr[count] + Func(arr, count + 1);
        }
    }
}
