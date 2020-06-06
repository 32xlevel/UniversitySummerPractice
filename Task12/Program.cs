/*
 * Выполнить сравнение двух предложенных методов сортировки одномерных массивов, содержащих n элементов, по количеству пересылок и сравнений
 * Для этого необходимо выполнить программную реализацию двух методов сортировки
 * Провести анализ методов сортировки для трех массивов: упорядоченного по возрастанию, упорядоченного по убыванию и неупорядоченного
 * Все три массива следует отсортировать обоими методами сортировки
 * Найти в литературе теоретические оценки сложности каждого из методов и сравнить их с оценками, полученными на практике
 * Сделать выводы о том, насколько отличаются теоретические и практические оценки количества операций, объяснить почему это происходит. Сравнить оценки сложности двух алгоритмов
 *
 * Сортировка простым выбором
 * Сортировка с помощью двоичного дерева
 */

using System;

// ReSharper disable ParameterTypeCanBeEnumerable.Local
// ReSharper disable ArrangeThisQualifier
// ReSharper disable MemberCanBePrivate.Local
// ReSharper disable InconsistentNaming

namespace Task12
{
    public class Program
    {
        public static void Main()
        {
            // Неупорядоченные массивы
            var array1_1 = new[] {7, 0, 3, -2, 6, 9, -5, 8, 1, 4};
            var array1_2 = new[] {7, 0, 3, -2, 6, 9, -5, 8, 1, 4};

            // Упорядоченные массивы по возрастанию
            var array2_1 = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            var array2_2 = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            // Упорядоченные массивы по убыванию
            var array3_1 = new[] {10, 9, 8, 7, 6, 5, 4, 3, 2, 1};
            var array3_2 = new[] {10, 9, 8, 7, 6, 5, 4, 3, 2, 1};

            var simpleChoiceSort1 = SortSimpleChoice(array1_1);
            var binarySort1 = SortWithBinaryTree(array1_2);
            
            var simpleChoiceSort2 = SortSimpleChoice(array2_1);
            var binarySort2 = SortWithBinaryTree(array2_2);
            
            var simpleChoiceSort3 = SortSimpleChoice(array3_1);
            var binarySort3 = SortWithBinaryTree(array3_2);
            
            PrintResults(SortedTypes.SimpleChoice, simpleChoiceSort1);
            Console.WriteLine();
            PrintResults(SortedTypes.WithBinaryTree, binarySort1);
            Console.WriteLine();
            
            PrintResults(SortedTypes.SimpleChoice, simpleChoiceSort2);
            Console.WriteLine();
            PrintResults(SortedTypes.WithBinaryTree, binarySort2);
            Console.WriteLine();
            
            PrintResults(SortedTypes.SimpleChoice, simpleChoiceSort3);
            Console.WriteLine();
            PrintResults(SortedTypes.WithBinaryTree, binarySort3);
        }

        /*
         * https://ru.wikipedia.org/wiki/%D0%A1%D0%BE%D1%80%D1%82%D0%B8%D1%80%D0%BE%D0%B2%D0%BA%D0%B0_%D1%81_%D0%BF%D0%BE%D0%BC%D0%BE%D1%89%D1%8C%D1%8E_%D0%B4%D0%B2%D0%BE%D0%B8%D1%87%D0%BD%D0%BE%D0%B3%D0%BE_%D0%B4%D0%B5%D1%80%D0%B5%D0%B2%D0%B0
         */
        private static SortResult SortWithBinaryTree(int[] array)
        {
            if (array == null) throw new NullReferenceException();
            if (array.Length < 2) return new SortResult(array, 0, 0);

            var tree = new Tree(array[0]);
            for (var i = 1; i < array.Length; i++)
            {
                tree.Add(new Tree(array[i]));
            }

            return new SortResult(tree.ToList().ToArray(), tree.CountComparison, 0);
        }

        // https://prog-cpp.ru/sort-select/
        // https://www.intuit.ru/studies/higher_education/3406/courses/504/lecture/11435?page=2
        private static SortResult SortSimpleChoice(int[] array)
        {
            if (array == null) throw new NullReferenceException();
            if (array.Length < 2) return new SortResult(array, 0, 0);

            var countComparison = 0;
            var countExchange = 0;

            for (var i = 0; i < array.Length - 1; i++)
            {
                var min = i;

                for (var j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[min]) min = j;
                    countComparison++;
                }

                var temp = array[i];
                array[i] = array[min];
                array[min] = temp;
                countExchange++;
            }

            return new SortResult(array, countComparison, countExchange);
        }

        private static void PrintResults(SortedTypes type, SortResult result)
        {
            if (type.Equals(SortedTypes.SimpleChoice)) Console.WriteLine("Сортировка простым выбором:");
            else if (type.Equals(SortedTypes.WithBinaryTree)) Console.WriteLine("Сортировка бинарным деревом:");
            
            Console.WriteLine("Полученный массив: ");
            PrintArray(result.Array);
            Console.WriteLine($"Количество сравнений: {result.CountComparison}\nКоличество пересылок: {result.CountExchange}");
        }

        private static void PrintArray(int[] array)
        {
            foreach (var item in array)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
        }

        private class SortResult
        {
            public readonly int[] Array;
            public readonly int CountComparison; // Количество сравнений
            public readonly int CountExchange; // Количество пересылок

            public SortResult(int[] array, int countComparison, int countExchange)
            {
                this.Array = array;
                this.CountComparison = countComparison;
                this.CountExchange = countExchange;
            }
        }
        
        private enum SortedTypes
        {
            SimpleChoice,
            WithBinaryTree
        }
    }
}