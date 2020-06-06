﻿using System;

/*
 * Определить, принадлежит ли точка заштрихованной области
 * №59е, книга Абрамова.
 * https://prnt.sc/s2afyh
 */
namespace Task03
{
    public class Program
    {
        public static void Main()
        {
            var x = Utilities.Utilities.ReadDouble("Введите x: ");
            var y = Utilities.Utilities.ReadDouble("Введите y: ");

            var isInArea = IsInArea(x, y);

            Console.WriteLine(isInArea ? "Точка попадает в область" : "Точка не попадает в область");
        }

        public static bool IsInArea(double x, double y)
        {
            var circleCondition = x <= Math.Sqrt(1 - y * y);
            var linearCondition1 = y >= -0.5 * x - 1;
            var linearCondition2 = y <= 0.5 * x + 1;
            return circleCondition && linearCondition1 && linearCondition2;
        }
    }
}