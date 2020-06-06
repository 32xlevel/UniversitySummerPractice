/*
 * Используя рекурсию, реализовать программу, решающую задачу:
 * Ввести а1, а2, а3, М, N. Построить последовательность чисел а[к] = 2 * | а[к–1] – а[k-2] | + а[к–3].
   Построить N элементов последовательности, либо найти первые M ее элементов,
   кратных трем (в зависимости от того, что выполнится раньше). Напечатать
   последовательность и причину остановки
 * https://prnt.sc/sfs12x
 */
using System;
using System.Collections.Generic;

namespace Task06
{
    public class Program
    {
        public static void Main()
        {
            var a1 = Utilities.Utilities.ReadInt("Введите a1: ");
            var a2 = Utilities.Utilities.ReadInt("Введите a2: ");
            var a3 = Utilities.Utilities.ReadInt("Введите a3: ");
            var m = Utilities.Utilities.ReadInt("Введите M: ");
            var n = Utilities.Utilities.ReadInt("Введите N: ");

            var result = FindNElementsOrMElementsThatMultiply3(n, m, a1, a2, a3);
            
            Console.WriteLine($"Причина остановки: {result.StopReason}");
            foreach (var element in result.ResultList)
            {
                Console.WriteLine(element);
            }
        }

        public static Result FindNElementsOrMElementsThatMultiply3(int n, int m, int a1, int a2, int a3)
        {
            if (n < 0) throw new ArgumentException($"n должен быть строго неотрицательным. Передано n = {n}");
            if (m < 0) throw new ArgumentException($"m должен быть строго неотрицательным. Передано m = {m}");
            if (n == 0) return new Result(new List<int>(0), StopReason.FoundN);

            var elements = new List<int>(n);
            var countElementsThatMultiple3 = 0;
            
            for (var k = 1; k <= n; k++)
            {
                var element = CalculateElement(k, a1, a2, a3);
                elements.Add(element);
                if (element % 3 == 0) countElementsThatMultiple3++;

                // Если нашли M элементов, делящихся на 3
                // Дополнительная проверка на то, что M не нуль
                if (countElementsThatMultiple3 == m && m != 0)
                {
                    return new Result(elements, StopReason.FoundMThatMultiply3);
                }
            }

            return new Result(elements, StopReason.FoundN);
        }
        
        public class Result
        {
            public readonly List<int> ResultList;
            public readonly StopReason StopReason;

            public Result(List<int> resultList, StopReason stopReason)
            {
                this.ResultList = resultList;
                this.StopReason = stopReason;
            }
        }

        public enum StopReason
        {
            FoundN, FoundMThatMultiply3
        }
            
        // Рекурсивное вычисление элемента согласно заданию
        private static int CalculateElement(int k, int a1, int a2, int a3)
        {
            switch (k)
            {
                case 1:
                    return a1;
                case 2:
                    return a2;
                case 3:
                    return a3;
                default:
                    return 2 * Math.Abs(CalculateElement(k - 1, a1, a2, a3) - CalculateElement(k - 2, a1, a2, a3)) + CalculateElement(k - 3, a1, a2, a3);
            }
        }
    }
}