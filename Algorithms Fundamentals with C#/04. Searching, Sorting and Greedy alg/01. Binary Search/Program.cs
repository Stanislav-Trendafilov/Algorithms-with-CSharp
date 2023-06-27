using System;
using System.Linq;

namespace _01._Binary_Search
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .OrderBy(x => x)
                .ToArray();

            int num = int.Parse(Console.ReadLine());
            Console.WriteLine(BinarySearch(arr, num));

        }
        static int BinarySearch(int[] numbers, int searchNumber)
        {
            var left = 0;
            var right = numbers.Length - 1;
            while (left <= right)
            {
                var mid = (left + right) / 2;
                if (numbers[mid] == searchNumber)
                {
                    return mid;
                }
                if (searchNumber > numbers[mid])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return -1;

        }
    }
}
