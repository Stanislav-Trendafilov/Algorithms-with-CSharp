using System;
using System.Linq;

namespace _04._Insertion_Sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[]nums=Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            InsertionSort(nums);
        }

        private static void InsertionSort(int[] nums)
        {
            for (int i = 1; i < nums.Length; i++)
            {
                int j = i;
                while(j>0)
                {
                    if (nums[j - 1] > nums[j])
                    {
                        int swap = nums[j - 1];
                        nums[j - 1] = nums[j];
                        nums[j] = swap;
                    }
                    j--;
                }
            }
            Console.WriteLine(string.Join(" ",nums));
        }
    }
}
