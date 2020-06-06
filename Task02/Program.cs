﻿using System.IO;
 
// https://acmp.ru/index.asp?main=task&id_task=842 
namespace Task02
{
    public class Program
    {
        private const string InputFile = "INPUT.TXT";
        private const string OutputFile = "OUTPUT.TXT";
        
        public static void Main()
        {
            var n = ulong.Parse(File.ReadAllText(InputFile));
            var answer = "YES";
            if (IsInfinityFraction(n)) answer = "NO";
            
            File.WriteAllText(OutputFile, answer);
        }

        // Дробь в десятичном виде - бесконечная? 
        private static bool IsInfinityFraction(ulong number) {
            if (number % 2 == 0) {
                while (number % 2 == 0) {
                    number /= 2;
                }
            }
            if (number % 5 == 0) {
                while (number % 5 == 0) {
                    number /= 5;
                }
            }
            return number == 1;
        }
    }
}