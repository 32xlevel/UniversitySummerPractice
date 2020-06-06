/*
 * Дано:
 * - натуральное число n,
 * - действительные числа a(1) .. a(n)
 * Если последовательность упорядочена по неубыванию, то оставить ее без изменений, иначе получить последовательность a(n)..a(1)
 */
using System;

namespace Task10
{
    public class Solution
    {
        public static void Main()
        {
            var n = Utilities.Utilities.ReadInt("Введите натуральное число: ");
            if (n < 1) throw new ArgumentException($"n должен быть натуральным. Передано: {n}");
            
            var random = new Random();
            var myLinkedList = new MyLinkedList<int>();

            for (var i = 0; i < n; i++) myLinkedList.Add(random.Next(0, 100));

            if (IsSorted(myLinkedList))
            {
                Console.WriteLine("Последовательность упорядочена по неубыванию");
                Console.WriteLine(myLinkedList);
            }
            else
            {
                Console.WriteLine("Последовательность НЕ упорядочена по неубыванию");
                Console.WriteLine(myLinkedList);
                
                var newList = new MyLinkedList<int>();
                for (int i = (int) (myLinkedList.Count - 1); i >= 0; i--)
                {
                    newList.Add(myLinkedList.GetByIndex((uint) i));
                }
                
                Console.WriteLine("Разворачиваем...");
                Console.WriteLine(newList);
            }
        }

        private static bool IsSorted(MyLinkedList<int> myLinkedList)
        {
            for (uint i = 1; i < myLinkedList.Count; i++)
            {
                if (myLinkedList.GetByIndex(i - 1) > myLinkedList.GetByIndex(i))
                {
                    return false;
                }
            }

            return true;
        }
    }
}