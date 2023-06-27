using System;
using System.Linq;

namespace _06._Merge_Sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var sorted = MergeSort(nums);

            Console.WriteLine(string.Join(" ", sorted));
        }

        private static int[] MergeSort(int[] nums)
        {
            if (nums.Length <= 1)
            {
                return nums;
            }
            var left = nums.Take(nums.Length / 2).ToArray();
            var right = nums.Skip(nums.Length / 2).ToArray();

            return MergeSort(MergeSort(left), MergeSort(right));


        }

        private static int[] MergeSort(int[] left, int[] right)
        {
            var merged = new int[left.Length + right.Length];

            var mergedInd = 0;
            var leftInd = 0;
            var rightInd = 0;

            while(leftInd<left.Length&&rightInd<right.Length)
            {
                if (left[leftInd] < right[rightInd])
                {
                    merged[mergedInd++] = left[leftInd++];
                }
                else
                {
                    merged[mergedInd++] = right[rightInd++];
                }
            }
            for (int i = leftInd; i < left.Length; i++)
            {
                merged[mergedInd++] = left[i];
            }
            for (int i = rightInd; i < right.Length; i++)
            {
                merged[mergedInd++] = right[i];
            }
            return merged;
        }
    }
}
