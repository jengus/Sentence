using System;
using System.Collections.Generic;
using System.Linq;

namespace Sentence
{
    class Program
    {
        static int punctuat(string text)
        {
            int amount = 0;
            char[] symb = text.ToCharArray();
            foreach (char symb1 in symb)
            {
                if ((symb1 == '"') || (symb1 == '.') || (symb1 == ',')
                    || (symb1 == '-') || (symb1 == '!') || (symb1 == '?')
                    || (symb1 == ':') || (symb1 == ';') || (symb1 == '(')
                    || (symb1 == ')'))
                    amount = amount + 1;
            }
            return amount;
        }
        static string[] Separation(string text)
        {
            string[] sentences = text.Split('.');
            sentences = sentences.Where(x => x != "").ToArray();
            return sentences;
        }
        static string[] SeparationWords(string text)
        {
            string[] words = text.Split(' ','.',',','!','?','-',';',':','"','(',')');
            words = words.Where(x => x != "").ToArray();
            return words;
        }
        static string TheLongestWord(string[] words)
        {
            int max = 0;
            string maxWord = "Нет слов.";
            foreach (string word in words)
            {
                if (word.Length >= max)
                {
                    max = word.Length;
                    maxWord = word;
                }
            }
            return maxWord;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст");
            string text = Console.ReadLine();
            Console.WriteLine($"Кол-во знаков препинавния:{punctuat(text)}");
            Console.WriteLine("Отдельно предложения текста");
            foreach (string sentence in Separation(text))
            {
                Console.WriteLine($"{sentence.Trim()}.");
            }
            Console.WriteLine($"Уникальные слова:");
            foreach (string word in SeparationWords(text).Distinct(StringComparer.CurrentCultureIgnoreCase))
            {
                Console.WriteLine($"{word.ToLower()}");
            }
            Console.WriteLine($"Самое длинное слово: {TheLongestWord(SeparationWords(text)).ToLower()}");
        }
    }
}
