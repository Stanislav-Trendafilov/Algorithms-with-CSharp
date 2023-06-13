using System;

namespace _02._RecursiveDrawing
{
    internal class Program
    {
       static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Draw(n);
        }
        static void Draw(int n)
        {
            for(int i = 1; i <= n; i++)
            {
                Console.Write("*");
            }
            if (n <= 0)
            {
                return;
            }
            Console.WriteLine();
            Draw(n - 1);
            for (int i = 1; i <= n; i++)
            {
                Console.Write("#");
            }
            Console.WriteLine();
        }
    }
}
