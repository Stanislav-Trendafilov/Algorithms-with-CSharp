﻿using System;

namespace _07._RecursiveFibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n=int.Parse(Console.ReadLine());

            Console.WriteLine(Fibonacci(n));
        }

        private static int Fibonacci(int n)
        {
            if(n<=1)
            {
                return 1;
            }

            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }
}
