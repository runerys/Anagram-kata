namespace Anagram
{
    using System.Collections.Generic;
    using System.Diagnostics;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AnagramTests
    {
        [TestMethod]
        public void GivenOneWord_ShouldNotPrintIt()
        {
            var word = new[] { "word" };
            var printedLines = new List<string>();

            RunFinder(word, printedLines);

            Assert.IsFalse(printedLines.Contains("word"), "Should not print the word");
        }

        [TestMethod]
        public void GivenTwoAnagramsAndOneOther_ShouldPrintOnlyAnagrams()
        {
            var word = new[] { "word", "drow", "crow" };
            var printedLines = new List<string>();

            RunFinder(word, printedLines);

            Assert.IsTrue(printedLines.Contains("word drow"), "Should have printed the words in same line");
            Assert.IsFalse(printedLines.Contains("crow"), "Should skip word not anagram");
        }

        [TestMethod]
        public void GivenTwoAnagrams_ShouldPrintItInOneLine()
        {
            var word = new[] { "word", "drow" };
            var printedLines = new List<string>();

            RunFinder(word, printedLines);

            Assert.IsTrue(printedLines.Contains("word drow"), "Should have printed the words in same line");
        }

        [TestMethod]
        public void GivenTwoAnagrams_ShouldPrintBothInTwoLines()
        {
            var word = new[] { "word", "drow", "blue", "lueb" };
            var printedLines = new List<string>();

            RunFinder(word, printedLines);

            Assert.AreEqual(2, printedLines.Count);
            Assert.IsTrue(printedLines.Contains("word drow"), "Should have printed the words in same line");
            Assert.IsTrue(printedLines.Contains("blue lueb"), "Should have printed the words in same line");
        }

        //[TestMethod]
        //public void GivenDuplicated_ShouldOnlyBePrintedOnce()
        //{
        //    var word = new[] { "word", "drow", "word" };
        //    var printedLines = new List<string>();

        //    RunFinder(word, printedLines);

        //    Assert.IsTrue(printedLines.Contains("word drow"), "No duplicates");
        //}

        [TestMethod]
        public void GivenTwoAnagramsPollutedWithWhitespace_ShouldPrintItInOneLine()
        {
            var word = new[] { " word", "  drow" };
            var printedLines = new List<string>();

            RunFinder(word, printedLines);

            Assert.IsTrue(printedLines.Contains("word drow"), "Should have printed the words in same line");
        }

        [TestMethod]
        public void GivenTwoAnagramsWithDifferentCase_ShouldPrintItInOneLine()
        {
            var word = new[] { "word", "DRow" };
            var printedLines = new List<string>();

            RunFinder(word, printedLines);

            Assert.IsTrue(printedLines.Contains("word drow"), "Should have printed the words in same line");
        }

        [TestMethod]
        public void PerformanceTest()
        {
            var realwords = @"C:\Users\rune.rystad\Downloads\wordlist.txt";

            var anagramFinder = new AnagramFinderOriginal();
            
            var lines = new List<string>();
            anagramFinder.PrintLine = lines.Add;

            var stopwatch = Stopwatch.StartNew();
            anagramFinder.FindInFile(realwords);            
            stopwatch.Stop();

            //lines.ForEach(Console.WriteLine);

            Debug.WriteLine("Found {0} anagrams in {1}ms",  lines.Count, stopwatch.ElapsedMilliseconds);
        }



        private static void RunFinder(string[] word, List<string> printedLines)
        {
            var finder = new AnagramFinderOriginal();
            finder.ReadFile = filename => word;
            finder.PrintLine = printedLines.Add;

            finder.FindInFile("anyfilename");
        }
    }
}