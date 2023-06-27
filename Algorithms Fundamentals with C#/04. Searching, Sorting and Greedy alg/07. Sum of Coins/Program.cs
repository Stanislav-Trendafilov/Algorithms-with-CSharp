using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Sum_of_Coins
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] coins = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int sum = int.Parse(Console.ReadLine());

            FindCoins(sum, coins);
        }

        private static void FindCoins(int sum, int[] coins)
        {
            bool succeded = true;
            coins = coins.OrderByDescending(x => x).ToArray();
            Dictionary<int, int> coinsCount = new Dictionary<int, int>();
            int i = 0;
            while (true)
            {
                if(sum==0||i>=coins.Length)
                {
                    break;
                }

                if (coins[i] <= sum)
                {
                    if (!coinsCount.ContainsKey(coins[i]))
                    {
                        coinsCount[coins[i]] = 0;
                    }
                    coinsCount[coins[i]]++;
                    sum -= coins[i];
                }
                else
                {
                    i++;
                }
            }
            if (sum == 0)
            {
                Console.WriteLine($"Number of coins to take: {coinsCount.Values.Sum()}");
                foreach (var (coin, count) in coinsCount)
                {
                    Console.WriteLine($"{count} coin(s) with value {coin}");
                }
            }
            else
            {
                Console.WriteLine("Error");
            }

        }
    }
}
