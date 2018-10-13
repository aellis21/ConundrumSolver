using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConundrumSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("input: ");

                var input = Console.ReadLine();
                input.Replace(" ", string.Empty);
                List<char> letters = new List<char>();
                letters.AddRange(input.ToLowerInvariant());

                List<string> wordList = new List<string>();
                wordList = GetInitialList(letters);
                wordList = FindWords(letters, wordList);

                wordList.Sort();
                wordList = wordList.Distinct().OrderBy(w => w.Length).ToList();

                foreach (var word in wordList)
                {
                    Console.WriteLine(word);
                }

                Console.WriteLine("--------");
            }
        }


        static List<string> FindWords(List<char> letters, List<string> words)
        {
            var result = new List<string>();
            var tempLetters = new List<char>();
            bool breakWord = false;
            foreach (var word in words)
            {
                breakWord = false;
                tempLetters.Clear();
                tempLetters.AddRange(letters);
                foreach (var letter in word)
                {
                    if (tempLetters.Contains(letter))
                    {
                        tempLetters.Remove(letter);
                        continue;
                    }
                    breakWord = true;
                    break;
                }
                if (!breakWord && word.Length > 2)
                {
                    result.Add(word);
                }
            }
            return result;
        }

        static List<string> GetInitialList(List<char> letters)
        {
            List<string> result = new List<string>();
            string line;
            string word;
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
                    if (result.Contains(word) || word.ToCharArray().FirstOrDefault() == '-' || word.ToCharArray().LastOrDefault() == '-')
                    {
                        line = sr.ReadLine();
                        continue;
                    }
                    while (char.IsDigit(word.ToCharArray().LastOrDefault()))
                    {
                        word = word.Remove(word.Length - 1);
                    }
                    if (letters.Contains(word.First()) && letters.Count >= word.Length)
                    {
                        result.Add(word);
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
            return result;
        }
    }
}
