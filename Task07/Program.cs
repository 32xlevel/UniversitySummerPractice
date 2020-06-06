/*
 * Заданы частоты символов входного алфавита. Построить двоичный префиксный код Хаффмана.
 * Кодовые слова выписать в лексикографическом порядке
 */
using System;
using System.Collections.Generic;
// ReSharper disable RedundantIfElseBlock
// ReSharper disable ConvertIfStatementToSwitchStatement

namespace Task07
{
    public class Program
    {
        private const string EnglishAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        public static void Main()
        {
            var result = HuffmanEncode(new[] {5, 2, 2, 1, 1});
            foreach (var code in result)
            {
                Console.WriteLine($"Code: {code}");
            }
            
            HuffmanEncode(new[] {5, 2, 2, 1, 1});
        }

        /*
         * https://neerc.ifmo.ru/wiki/index.php?title=%D0%90%D0%BB%D0%B3%D0%BE%D1%80%D0%B8%D1%82%D0%BC_%D0%A5%D0%B0%D1%84%D1%84%D0%BC%D0%B0%D0%BD%D0%B0
         * 
         * На вход подается набор частот. Например: A - 5, B - 2, R - 2, C - 1, D - 1, сами символы не указываются
         * Возвращает список (в виде множества) двоичных префиксных кодов Хаффмана в лексикографическом порядке
         */
        public static SortedSet<string> HuffmanEncode(int[] frequencies)
        {
            // Частные случаи
            if (frequencies.Length == 0) return new SortedSet<string>();
            else if (frequencies.Length == 1) return new SortedSet<string> { "0" } ;
            else if (frequencies.Length == 2) return new SortedSet<string> { "0", "10" };

            var stringForEncode = BuildStringForEncode(frequencies);
            var result = Huffman.Encode(stringForEncode);

            return result;
        }

        private static string BuildStringForEncode(int[] frequencies)
        {
            var stringForEncode = "";
            for (var i = 0; i < frequencies.Length; i++)
            {
                var frequency = frequencies[i];
                if (frequency < 1) throw new ArgumentException($"Частота встречаемости символа должна быть выражена натуральным числом. Передано: {frequency}");
                
                var ch = EnglishAlphabet[i];
                for (var j = 0; j < frequency; j++)
                {
                    stringForEncode += ch;
                }
            }

            return stringForEncode;
        }
    }
}