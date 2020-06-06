using System.Collections.Generic;
using System.IO;
using System.Linq;

// https://acmp.ru/index.asp?main=task&id_task=178
namespace Task01
{
    public class Program
    {
        private const string InputFile = "INPUT.TXT";
        private const string OutputFile = "OUTPUT.TXT";

        public static void Main()
        {
            var numbers = ReadNumbersFromFile();
            
            var dictionary = new Dictionary<int, int>();
            var maxFrequency = 0; 
            var maxFrequencyNumbers = new List<int>();

            foreach (var number in numbers)
            {
                var hasNumber = dictionary.TryGetValue(number, out var value);
                
                int freq;
                if (!hasNumber) freq = 1;
                else freq = value + 1;

                if (freq == maxFrequency)
                {
                    maxFrequencyNumbers.Add(number);
                }

                if (freq > maxFrequency)
                {
                    maxFrequency = freq;
                    maxFrequencyNumbers.Clear();
                    maxFrequencyNumbers.Add(number);
                }

                dictionary[number] = freq;
            }

            // Поиск минимального элемента
            var minNumber = maxFrequencyNumbers.Min();
            
            var outputFile = new StreamWriter(OutputFile);
            foreach (var number in numbers)
            {
                if (number == minNumber) continue;
                outputFile.Write(number + " ");
            }

            for (var i = 0; i < maxFrequency; i++)
            {
                outputFile.Write(minNumber + " ");
            }
            
            outputFile.Close();
        }

        private static int[] ReadNumbersFromFile()
        {
            var lines = File.ReadAllLines(InputFile);
            var n = int.Parse(lines[0]);
            var numbersInString = lines[1].Split(' ');

            var numbers = new int[n];
            for (var i = 0; i < numbersInString.Length; i++)
            {
                numbers[i] = int.Parse(numbersInString[i]);
            }

            return numbers;
        }
    }
}