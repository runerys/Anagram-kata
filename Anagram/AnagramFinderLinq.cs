namespace Anagram
{
    using System;
    using System.IO;
    using System.Linq;

    
    
    
    public class AnagramFinderLinq
    {        
        public void FindInFile(string filename)
        {
            (
                from word in ReadFile(filename).AsParallel()
                let sorted = new string(word.ToCharArray().OrderBy(c => c).ToArray())
                group word by sorted into anagramGroup
                where anagramGroup.Count() > 1
                select string.Join(" ", anagramGroup)
            ).ToList()
             .ForEach(PrintLine);
        }
      
        public Func<string, string[]> ReadFile = filename => File.ReadAllLines(filename);
        public Action<string> PrintLine = line => Console.WriteLine(line);
    }
}