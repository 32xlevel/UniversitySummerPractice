/*
 * Граф задан списком вершин и ребер.
 * Найти в нем какую-либо простую цепь из K вершин.
 * Простой цепью называется маршрут без повторяющихся вершин (откуда следует, что в простой цепи нет повторяющихся рёбер)
 */

using System;
using System.Collections.Generic;

namespace Task08
{
    public class Program
    {
        public static void Main()
        {
            var edges = new List<Edge>
            {
                new Edge(0, 1),
                new Edge(1, 2),
                new Edge(2, 3),
                new Edge(0, 3)
            };

            var verticiesCount = Utilities.Utilities.ReadInt("Введите количество вершин в графе: ");
            var k = Utilities.Utilities.ReadInt("Введите натуральное число k: ");
            var result = SearchFirstChainWithKDepth(verticiesCount, edges, k);
            
            Console.WriteLine(result);
        }

        public static string SearchFirstChainWithKDepth(int verticiesCount, List<Edge> edges, int k)
        {
            if (verticiesCount < 1) throw new ArgumentException("Количество вершин должно быть выражено натуральным числом");
            if (k < 1) throw new ArgumentException("Число k должно быть выражено натуральным числом: ");
            foreach (var edge in edges)
            {
                if (edge.V1 < 0 || edge.V2 < 0 || edge.V1 >= verticiesCount || edge.V2 >= verticiesCount)
                {
                    throw new ArgumentException("Описание вершин графа должно быть в промежтке 0..verticiesCount-1");
                }
            }
            
            var colors = new int[verticiesCount];
            for (var i = 0; i < verticiesCount - 1; i++)
            {
                for (var j = i + 1; j < verticiesCount; j++)
                {
                    for (var z = 0; z < verticiesCount; z++)
                    {
                        colors[z] = 1;
                    }
                    var chain = DepthFirstSearch(i, j, edges, colors, (i + 1).ToString());
                    if (chain != null)
                    {
                        var chainVerticies = chain.Split('-');
                        if (chainVerticies.Length == k) return chain;
                    }
                }
            }

            return null;
        }
        
        private static string DepthFirstSearch(int startVertex, int endVertex, List<Edge> edges, int[] colors, string chain)
        {
            if (startVertex != endVertex)
            {
                colors[startVertex] = 2;
            }
            else
            {
                return chain;
            }

            foreach (var edge in edges)
            {
                if (colors[edge.V2] == 1 && edge.V1 == startVertex)
                {
                    var result = DepthFirstSearch(edge.V2, endVertex, edges, colors, chain + "-" + (edge.V2 + 1).ToString());
                    colors[edge.V2] = 1;
                    return result;
                }
                else if (colors[edge.V1] == 1 && edge.V2 == startVertex)
                {
                    var result = DepthFirstSearch(edge.V1, endVertex, edges, colors, chain + "-" + (edge.V1 + 1).ToString());
                    colors[edge.V1] = 1;
                    return result;
                }
            }
            
            return null;
        } 
    }

    // Класс, описывающий ребро
    public class Edge
    {
        // Номера вершин, которые соединяют ребро
        public readonly int V1;
        public readonly int V2;

        public Edge(int v1, int v2)
        {
            V1 = v1;
            V2 = v2;
        }
    }
}