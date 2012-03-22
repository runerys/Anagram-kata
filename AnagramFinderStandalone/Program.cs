using System;
using System.IO;
using System.Linq;

namespace AnagramFinderStandalone
{
    class Program
    {
        static void Main(string[] args)
        {
            (
                from word in ReadFile(args[0]).AsParallel()
                group word by new string(word.ToCharArray().OrderBy(c => c).ToArray()) into anagramGroup
                where anagramGroup.Count() > 1
                select string.Join(" ", anagramGroup)
            ).ToList()
             .ForEach(PrintLine);
        }

        public static Func<string, string[]> ReadFile = filename => File.ReadAllLines(filename);
        public static Action<string> PrintLine = line => Console.WriteLine(line);
    }
}
