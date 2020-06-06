/*
    Напишите метод создания линейного списка, в информационные поля элементов
    которого последовательно заносятся номера с 1 до N (N водится с клавиатуры).
    Элементы, содержащие отрицательные значения, заносятся всегда в конец списка, а
    положительные – в начало (в порядке считывания из файла), нулевые – между
    положительными и отрицательными. Разработайте методы поиска и удаления
    элементов списка
 */

using System;

namespace Task09
{
    public class Program
    {
        public static void Main()
        {
            var n = Utilities.Utilities.ReadInt("Введите n (больше 1): ");
            var node = AddNElements(n);
            Console.WriteLine(node.IsExist(0));
            Console.WriteLine(node.GetAt(5));
        }

        private static Node AddNElements(int n)
        {
            if (n <= 1) throw new ArgumentException($"Аргумент n должен быть больше 1. Передано: {n}");
            
            var random = new Random();
            
            var node = new Node();
            node.Data = random.Next(-10, 10);
                
            for (var i = 1; i <= n; i++)
            {
                var number = random.Next(-10, 10);
                node = node.Add(number);
            }

            return node;
        }
    }
}