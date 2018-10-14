using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConundrumSolver
{
    public class WordFinder
    {
        public Dictionary<string, string> WordDictionary { get; set; }

        public void SolveConundrum(string input)
        {
            input.Replace(" ", string.Empty).ToLowerInvariant();
            List<char> letters = new List<char>();
            letters.AddRange(input);

            GetInitialList(letters);
            FindWords(letters);

            WordDictionary = (Dictionary<string, string>) WordDictionary.OrderBy(w => w.Key).OrderBy(w => w.Key.Length);
        }

        public void FindWords(List<char> letters)
        {
            var result = new Dictionary<string, string>();
            var tempLetters = new List<char>();
            bool breakWord = false;
            foreach (var word in WordDictionary)
            {
                breakWord = false;
                tempLetters.Clear();
                tempLetters.AddRange(letters);
                foreach (var letter in word.Key)
                {
                    if (tempLetters.Contains(letter))
                    {
                        tempLetters.Remove(letter);
                        continue;
                    }
                    breakWord = true;
                    break;
                }
                if (!breakWord && word.Key.Length > 2)
                {
                    result.Add(word.Key, word.Value);
                }
            }
            WordDictionary = result;
        }

        public void GetInitialList(List<char> letters)
        {
            var result = new Dictionary<string, string>();
            string line;
            string word;
            string definition;
            try
            {
                StreamReader sr = new StreamReader(@"OxfordEnglishDictionary.txt");
                line = sr.ReadLine();
                while (line != null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        line = sr.ReadLine();
                        continue;
                    }
                    word = line.Split(' ').FirstOrDefault().ToLowerInvariant();
                    definition = line.Remove(0, word.Length);
                    var repeatWord = result.Any(d => d.Key == word);
                    if (repeatWord || word.ToCharArray().FirstOrDefault() == '-' || word.ToCharArray().LastOrDefault() == '-')
                    {
                        if (repeatWord)
                        {
                            definition = $"{result.FirstOrDefault(d => d.Key == word).Value}{Environment.NewLine}{Environment.NewLine}{definition}";
                            WordDictionary.Remove(word);
                            WordDictionary.Add(word, definition);
                        }
                        line = sr.ReadLine();
                        continue;
                    }
                    while (char.IsDigit(word.ToCharArray().LastOrDefault()))
                    {
                        word = word.Remove(word.Length - 1);
                    }
                    if (letters.Contains(word.First()) && letters.Count >= word.Length)
                    {
                        WordDictionary.Add(word, definition);
                    }
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.ReadKey();
                throw;
            }
        }
    }
}
