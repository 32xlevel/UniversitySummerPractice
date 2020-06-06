/*
 * Дана действительная квадратная матрица порядка N. Найти наибольшее из значений элементов,
 * расположенных в заштрихованной части матрицы
 * № 692(в)
 * https://prnt.sc/sfhy9n
 */
using System;
// ReSharper disable IdentifierTypo

namespace Task05
{
    public class Program
    {
        public static void Main()
        {
            var matrix3 = new[]
            {
                new[] {1.0, 2.0, 1.0},
                new[] {7.0, 1.0, 7.0},
                new[] {7.0, 7.0, 7.0}
            };
            
            var matrix5 = new[]
            {
                new[] {1.0, 1.0, 1.0, 1.0, 4.0},
                new[] {7.0, 1.0, 1.0, 1.0, 7.0},
                new[] {7.0, 7.0, 1.0, 7.0, 7.0},
                new[] {7.0, 7.0, 7.0, 7.0, 7.0},
                new[] {7.0, 7.0, 7.0, 7.0, 7.0}
            };

            Console.WriteLine(Max(matrix3));
            Console.WriteLine(Max(matrix5));
        }

        // Поиск максимального значения в квадратной матрице в указанной области
        public static double Max(double[][] matrix)
        {
            // Для поиска значений в заштрихованной области количество строк в матрице должен быть не меньше 3, а также
            // для определения "центрального" элемента требуется, чтобы количество строк было нечётным
            // https://prnt.sc/sfi4cz
            if (matrix.Length < 3 || matrix.Length % 2 != 1)
            {
                throw new ArgumentException($"Количество строк в матрице должно быть не меньше 3 и нечётным. Передано строк: {matrix.Length}");
            }

            var n = matrix.Length;
            
            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (var ints in matrix)
            {
                if (ints.Length != n) throw new ArgumentException("Передана не квадратная матрица");
            }
    
            var max = double.MinValue;
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    if (j >= i && n - j - 1 >= i && matrix[i][j] > max)
                    {
                        max = matrix[i][j];
                    }
                }
            }
            
            return max;
        }
    }
}