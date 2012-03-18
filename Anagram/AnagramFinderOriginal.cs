using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anagram
{
    using System.IO;

    public class AnagramFinderOriginal
    {
        public void FindInFile(string filename)
        {
            var readWords = ReadFile(filename);

            var anagramGroup = new Dictionary<string, List<string>>();

            foreach (var word in readWords)
            {
                var sorted = SortWord(word);

                if (!anagramGroup.ContainsKey(sorted))
                    anagramGroup.Add(sorted, new List<string> { word });
                else
                    anagramGroup[sorted].Add(word);
            }

            foreach (var words in anagramGroup.Values)
            {
                if (words.Count > 1)
                    PrintLine(string.Join(" ", words));
            }
        }

        private static string SortWord(string word)
        {
            char[] wordInChars = word.ToCharArray();
            Array.Sort(wordInChars);
            return new string(wordInChars);
        }

        public Func<string, string[]> ReadFile = filename => File.ReadAllLines(filename);
        public Action<string> PrintLine = line => Console.WriteLine(line);
    }
}
