using System;

namespace _01._Reverse_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split(' ');

            reversedArray = new string[arr.Length];
            ReverseArray(arr, 0);
        }
        private static string[] reversedArray;
        private static void ReverseArray(string[] arr, int ind)
        {
            if (ind >= arr.Length)
            {
                Console.WriteLine(string.Join(" ", reversedArray));
                return;
            }
            reversedArray[ind] = arr[arr.Length-ind-1];
            ReverseArray(arr, ind + 1);
            
            
        }
    }
}
