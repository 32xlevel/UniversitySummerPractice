using System;

/*
* Вычислить бесконечную сумму с заданной точностью eps
* №119(г) https://prnt.sc/sfg73t
*/
namespace Task04
{
    public class Program
    {
        public static void Main()
        {
            var epsilon = Utilities.Utilities.ReadDouble("Введите epsilon (точность вычисления) для бесконечного ряда: ");
            Console.WriteLine(CalculateInfiniteSum(epsilon));
        }

        public static double CalculateInfiniteSum(double epsilon)
        {
            if (epsilon <= 0 || epsilon >= 1) throw new ArgumentException($"Точность вычисления должна быть в интервале (0; 1). Передано: {epsilon}");
            
            var sum = 1.0; // Начальная сумма ряда с i = 0
            var element = 1.0;
            for (var i = 1; Math.Abs(element) > epsilon; i++)
            {
                element = Math.Pow(-2, i) / Factorial(i);
                sum += element;
            }

            return sum;
        }

        public static int Factorial(int n)
        {
            if (n < 0) throw new ArgumentException($"Аргумент для вычисления факторила должен быть неотрицательным. Передано: {n}");

            if (n == 0 || n == 1) return 1;
            var result = 1;

            for (var i = 2; i <= n; i++)
            {
                result *= i;
            }

            return result;
        }
    }
}