using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Task13Subtask2
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText("C:\\Users\\SuperUser\\Downloads\\Text1 (1).txt");

            CountingWords(text);
        }
        static void CountingWords(string text)
        {
            Dictionary<string, int> stats = new Dictionary<string, int>();

            char[] dilimiters = new char[] { ' ', '\r', '\n', ',', '.', '-', '!', '?', '"', ':' };
            string[] AllWords = text.Split(dilimiters);

            int minWordLength = 2;

            foreach (var word in AllWords)
            {
                string w = word.Trim().ToLower();
                if (w.Length >= minWordLength)
                {
                    if (!stats.ContainsKey(w))
                    {
                        stats.Add(w, 1);
                    }
                    else
                    {
                        stats[w] += 1;
                    }
                }
            }
            var orderedStats = stats.OrderByDescending(x => x.Value);

            Console.WriteLine("Количество всех слов : " + stats.Count);
            Console.WriteLine();

            foreach (var peir in orderedStats.Take(10))
            {
                Console.WriteLine("{0} - встречается в тексте: {1} раз", peir.Key, peir.Value);
            }
        }
    }

}


