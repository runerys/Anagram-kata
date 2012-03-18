using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnagramConsoleApp
{
    using System.Diagnostics;
    using System.IO;

    using Anagram;

    class Program
    {
        static void Main(string[] args)
        {
            var realwords = @"C:\Users\rune.rystad\Downloads\wordlist.txt";

            var anagramFinder = new AnagramFinderLinq();

            var lines = new List<string>();
            anagramFinder.PrintLine = lines.Add;

            var stopwatch = Stopwatch.StartNew();
            anagramFinder.FindInFile(realwords);
            anagramFinder.ReadFile = Read;

            stopwatch.Stop();

            Console.WriteLine("LINQ Found {0} anagrams in {1} ms", lines.Count, stopwatch.ElapsedMilliseconds);

            var anagramFinder2 = new AnagramFinderOriginal();

            lines = new List<string>();
            anagramFinder2.PrintLine = lines.Add;
            anagramFinder2.ReadFile = Read;

            stopwatch = Stopwatch.StartNew();
            anagramFinder2.FindInFile(realwords);
            stopwatch.Stop();

            Console.WriteLine("Original Found {0} anagrams in {1} ms", lines.Count, stopwatch.ElapsedMilliseconds);
            Console.ReadLine();
        }

        public static string[] Read(string filename)
        {
            List<string> words = new List<string>();
            using (var reader = new StreamReader(filename))
            {
                string word;
                while ((word = reader.ReadLine()) != null)
                {
                    words.Add(word);
                }
            }
            return words.ToArray();
        }

    }
}
