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
            var realwords = @"input\wordlist.txt";

            var anagramFinder = new AnagramFinderLinq();

            var lines = new List<string>();
            anagramFinder.PrintLine = lines.Add;

            var stopwatch = Stopwatch.StartNew();
            anagramFinder.FindInFile(realwords);
            stopwatch.Stop();

            Console.WriteLine("LINQ Found {0} anagrams in {1} ms", lines.Count, stopwatch.ElapsedMilliseconds);

            var anagramFinder2 = new AnagramFinderOriginal();
            lines = new List<string>();
            anagramFinder2.PrintLine = lines.Add;
            stopwatch = Stopwatch.StartNew();
            anagramFinder2.FindInFile(realwords);
            stopwatch.Stop();

            Console.WriteLine("Original Found {0} anagrams in {1} ms", lines.Count, stopwatch.ElapsedMilliseconds);
          
            lines = new List<string>();          
            stopwatch = Stopwatch.StartNew();          
            var anagrams = AnagramsFinderFSharp.findAnagramsInFile(realwords);
            lines.AddRange(anagrams);
            stopwatch.Stop();

            Console.WriteLine("F# Found {0} anagrams in {1} ms", lines.Count, stopwatch.ElapsedMilliseconds);
            Console.ReadLine();
        }     
    }
}
