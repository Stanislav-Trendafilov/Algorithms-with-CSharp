using System;
using System.Collections.Generic;

namespace _06._Word_Cruncher
{
    internal class Program
    {
        private static Dictionary<int, List<string>> wordsByIdx;
        private static Dictionary<string, int> wordsCount;
        private static LinkedList<string> usedWords;
        private static string target;
        static void Main(string[] args)
        {
            var words = Console.ReadLine().Split(", ");
            target = Console.ReadLine();

            wordsCount = new Dictionary<string, int>();
            wordsByIdx = new Dictionary<int, List<string>>();
            usedWords = new LinkedList<string>();
            foreach (var word in words)
            {
                var idx = target.IndexOf(word);
                if (idx == -1)
                {
                    continue;
                }
                if (wordsCount.ContainsKey(word))
                {
                    wordsCount[word]++;
                    continue;
                }

                wordsCount[word] = 1;
                while (idx != -1)
                {
                    if (!wordsByIdx.ContainsKey(idx))
                    {
                        wordsByIdx[idx] = new List<string>();
                    }
                    wordsByIdx[idx].Add(word);

                    idx = target.IndexOf(word, idx + 1);
                }
            }
            GenSolutions(0);
        }

        private static void GenSolutions(int ind)
        {
            if (ind == target.Length)
            {
                Console.WriteLine(string.Join(" ", usedWords));
                return;
            }
            if(!wordsByIdx.ContainsKey(ind))
            {
                return;
            }
            foreach (var word in wordsByIdx[ind])
            {
                
                if (wordsCount[word] == 0)
                {
                    continue;
                }
                wordsCount[word]--;
                usedWords.AddLast(word);

                GenSolutions(ind + word.Length);

                usedWords.RemoveLast();
                wordsCount[word]++;
            }
        }
    }
}
