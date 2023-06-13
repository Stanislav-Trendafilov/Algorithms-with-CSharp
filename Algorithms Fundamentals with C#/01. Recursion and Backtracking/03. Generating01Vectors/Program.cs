using System;

namespace _03._Generating01Vectors
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int n=int.Parse(Console.ReadLine());

            int[] arr = new int[n];

            Gen01(arr,0);
        }
                                                            
        private static void Gen01(int[] arr,int ind)
        {
            if(ind>=arr.Length)
            {
                Console.WriteLine(string.Join(String.Empty,arr));
                return;
            }
            for (int i = 0; i < 2; i++)
            {
                arr[ind] = i;
                Gen01(arr, ind + 1);
            }
        }


    }
}
