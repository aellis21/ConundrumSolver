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
            WordDictionary = new Dictionary<string, string>();
            input.Replace(" ", string.Empty).ToLowerInvariant();
            List<char> letters = new List<char>();
            letters.AddRange(input);

            GetInitialList(letters);
            FindWords(letters);

            OrderDictionary();
        }

        private void OrderDictionary()
        {
            var tempDict = WordDictionary.OrderBy(w => w.Key).OrderBy(w => w.Key.Length);
            WordDictionary = new Dictionary<string, string>();
            foreach (var word in tempDict)
            {
                WordDictionary.Add(word.Key, word.Value);
            }
        }

        private void FindWords(List<char> letters)
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

        private void GetInitialList(List<char> letters)
        {
            string word;
            string definition;

            StreamReader sr = new StreamReader(@"OxfordEnglishDictionary.txt");
            string line = sr.ReadLine();
            while (line != null)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    line = sr.ReadLine();
                    continue;
                }

                word = ExtractWordFromLine(line);

                definition = line.Remove(0, word.Length).Trim();

                if (!IsValidWord(word, definition, letters))
                {
                    line = sr.ReadLine();
                    continue;
                }

                AddWordToDictionary(letters, word, definition);

                line = sr.ReadLine();
            }
            sr.Close();

        }

        private void AddWordToDictionary(List<char> letters, string word, string definition)
        {
            if (letters.Contains(word.First()) && letters.Count >= word.Length)
            {
                WordDictionary.Add(word, definition);
            }
        }

        private bool IsValidWord(string word, string definition, List<char> letters)
        {
            var repeatWord = WordDictionary.Any(d => d.Key == word);
            if (repeatWord || word.ToCharArray().FirstOrDefault() == '-' || word.ToCharArray().LastOrDefault() == '-')
            {
                if (repeatWord)
                {
                    string tempDefinition = $"{WordDictionary.FirstOrDefault(d => d.Key == word).Value}{Environment.NewLine}{Environment.NewLine}{definition}";
                    WordDictionary.Remove(word);
                    AddWordToDictionary(letters, word, tempDefinition);
                }
                return false;
            }
            return true;
        }

        private string ExtractWordFromLine(string line)
        {
            string word = line.Split(' ').FirstOrDefault().ToLowerInvariant();
            while (char.IsDigit(word.ToCharArray().LastOrDefault()))
            {
                word = word.Remove(word.Length - 1);
            }

            return word;
        }
    }
}
