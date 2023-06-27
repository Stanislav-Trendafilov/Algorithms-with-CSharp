using System;
using System.Linq;

namespace _02._Selection_Sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            SelectionSort(arr);

        }
        private static int ind;
        private static void SelectionSort(int[] arr)
        {
            ind = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int min = arr[i];
                for (int curr = i + 1; curr < arr.Length; curr++)
                {
                    if (min > arr[curr])
                    {
                        min = arr[curr];
                        ind = curr;
                    }
                }
                if (arr[i] != min)
                {
                    int swap = arr[i];
                    arr[i] = min;
                    arr[ind] = swap;

                }
            }
            Console.WriteLine(string.Join(" ", arr));
        }


    }
}
