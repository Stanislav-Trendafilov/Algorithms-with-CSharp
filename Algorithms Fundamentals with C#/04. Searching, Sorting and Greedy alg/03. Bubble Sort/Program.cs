using System;
using System.Linq;

namespace _03._Bubble_Sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            BubbleSort(arr);

        }
        private static int ind;
        private static void BubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 1; j < arr.Length - i; j++)
                {
                    if (arr[j - 1] > arr[j])
                    {
                        int swap = arr[j - 1];
                        arr[j - 1] = arr[j];
                        arr[j] = swap;
                    }
                }
            }
            Console.WriteLine(string.Join(" ", arr));
        }


    }
}
