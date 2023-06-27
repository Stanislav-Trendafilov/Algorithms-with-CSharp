using System;
using System.Linq;

namespace _05._Quicksort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            QuickSort(nums, 0, nums.Length - 1);

            Console.WriteLine(string.Join(" ", nums));
        }

        private static void QuickSort(int[] nums, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            

            int pivot = start;
            int left = start + 1;
            int right = end;
            while (left <= right)
            {
                if (nums[left] > nums[pivot] && nums[right] < nums[pivot])
                {
                    int swap = nums[left];
                    nums[left] = nums[right];
                    nums[right] = swap;
                }
                if (nums[left] <= nums[pivot])
                {
                    left += 1;
                }
                if (nums[right] >= nums[pivot])
                {
                    right -= 1;
                }
                int swap1 = nums[right];
                nums[right] = nums[pivot];
                nums[pivot] = swap1;

                QuickSort (nums,start, right-1);
                QuickSort(nums,right+1, end);
            }
        }
    }
}
