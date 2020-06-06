using System;
using System.Collections.Generic;
using NUnit.Framework;
using Task08;
using Task09;
using Program = Task03.Program;

namespace AllTests
{
    [TestFixture]
    public class Tests
    {
        #region Task03
        [Test]
        public void IsInAreaTest()
        {
            Assert.AreEqual(true, Program.IsInArea(0, 0));
            Assert.AreEqual(true, Program.IsInArea(0.5, -0.3));
            Assert.AreEqual(true, Program.IsInArea(1, 0)); // Граница
            Assert.AreEqual(true, Program.IsInArea(0, -1)); // Граница
            Assert.AreEqual(true, Program.IsInArea(0, 1)); // Граница
            Assert.AreEqual(true, Program.IsInArea(-2, 0)); // Граница

            Assert.AreEqual(false, Program.IsInArea(1, 1));
            Assert.AreEqual(false, Program.IsInArea(-1, -1));
            Assert.AreEqual(false, Program.IsInArea(-1, 1.5));
            Assert.AreEqual(false, Program.IsInArea(-1, -1.5));
        }
        #endregion

        #region Task04
        [Test]
        public void CalculateInfiniteSumTest()
        {
            Assert.AreEqual(0.155555555555556, Task04.Program.CalculateInfiniteSum(0.1));
            Assert.AreEqual(0.136507936507937, Task04.Program.CalculateInfiniteSum(0.01));
            Assert.AreEqual(0.135379188712522, Task04.Program.CalculateInfiniteSum(0.001));
            Assert.AreEqual(0.135327881994549, Task04.Program.CalculateInfiniteSum(0.0001));
            Assert.AreEqual(0.135336433114211, Task04.Program.CalculateInfiniteSum(0.00001));
        }

        [Test]
        public void CalculateInfiniteSumArgumentExceptionTest()
        {
            Assert.Throws<ArgumentException>(() => Task04.Program.CalculateInfiniteSum(1));
            Assert.Throws<ArgumentException>(() => Task04.Program.CalculateInfiniteSum(0));
            Assert.Throws<ArgumentException>(() => Task04.Program.CalculateInfiniteSum(-5));
            Assert.Throws<ArgumentException>(() => Task04.Program.CalculateInfiniteSum(10));
        }

        [Test]
        public void FactorialTest()
        {
            Assert.AreEqual(1, Task04.Program.CalculateInfiniteSum(0));
            Assert.AreEqual(1, Task04.Program.CalculateInfiniteSum(1));
            Assert.AreEqual(120, Task04.Program.CalculateInfiniteSum(5));
        }

        [Test]
        public void FactorialArgumentExceptionTest()
        {
            Assert.Throws<ArgumentException>(() => Task04.Program.CalculateInfiniteSum(-10));
        }
        #endregion

        #region Task05
        [Test]
        public void MaxTest()
        {
            var matrix1 = new[]
            {
                new[] {5.0, 1, 1, 1, 1},
                new[] {7.0, 1, 1, 1, 7},
                new[] {7.0, 7, 1, 7, 7},
                new[] {7.0, 7, 7, 7, 7},
                new[] {7.0, 7, 7, 7, 7}
            };

            var matrix2 = new[]
            {
                new[] {1.0, 1, 1, 1, 1},
                new[] {7.0, 5, 1, 1, 7},
                new[] {7.0, 7, 1, 7, 7},
                new[] {7.0, 7, 7, 7, 7},
                new[] {7.0, 7, 7, 7, 7}
            };

            var matrix3 = new[]
            {
                new[] {1.0, 1, 1, 1, 1},
                new[] {7.0, 1, 1, 1, 7},
                new[] {7.0, 7, 5, 7, 7},
                new[] {7.0, 7, 7, 7, 7},
                new[] {7.0, 7, 7, 7, 7}
            };

            var matrix4 = new[]
            {
                new[] {1.0, 1, 1, 1, 1},
                new[] {7.0, 1, 1, 5, 7},
                new[] {7.0, 7, 1, 7, 7},
                new[] {7.0, 7, 7, 7, 7},
                new[] {7.0, 7, 7, 7, 7}
            };

            var matrix5 = new[]
            {
                new[] {1.0, 1, 1, 1, 5},
                new[] {7.0, 1, 1, 1, 7},
                new[] {7.0, 7, 1, 7, 7},
                new[] {7.0, 7, 7, 7, 7},
                new[] {7.0, 7, 7, 7, 7}
            };

            var matrix6 = new[]
            {
                new[] {1.0, 1, 1, 1, 1},
                new[] {7.0, 1, 5, 1, 7},
                new[] {7.0, 7, 1, 7, 7},
                new[] {7.0, 7, 7, 7, 7},
                new[] {7.0, 7, 7, 7, 7}
            };

            Assert.AreEqual(5, Task05.Program.Max(matrix1));
            Assert.AreEqual(5, Task05.Program.Max(matrix2));
            Assert.AreEqual(5, Task05.Program.Max(matrix3));
            Assert.AreEqual(5, Task05.Program.Max(matrix4));
            Assert.AreEqual(5, Task05.Program.Max(matrix5));
            Assert.AreEqual(5, Task05.Program.Max(matrix6));
        }

        [Test]
        public void MaxExceptionTest()
        {
            var matrix1 = new[]
            {
                new[] {1.0}
            };
            var matrix2 = new[]
            {
                new[] {1.0, 1},
                new[] {1.0, 1}
            };
            var matrix3 = new[]
            {
                new[] {1.0, 1, 1, 1},
                new[] {7.0, 1, 5, 1},
                new[] {7.0, 7, 1, 7},
                new[] {7.0, 7, 7, 7}
            };
            var nonQuadroMatrix = new[]
            {
                new[] {1.0, 1, 1, 1, 5},
                new[] {7.0, 1, 5, 1, 5},
                new[] {7.0, 7, 1, 7, 5},
                new[] {7.0, 7, 7, 7, 5}
            };

            Assert.Throws<ArgumentException>(() => Task05.Program.Max(matrix1));
            Assert.Throws<ArgumentException>(() => Task05.Program.Max(matrix2));
            Assert.Throws<ArgumentException>(() => Task05.Program.Max(matrix3));
            Assert.Throws<ArgumentException>(() => Task05.Program.Max(nonQuadroMatrix));
        }
        #endregion

        #region Task06

        [Test]
        public void FindNElementsOrMElementsThatMultiply3Test()
        {
            var result1 = Task06.Program.FindNElementsOrMElementsThatMultiply3(n: 15, m: 0, a1: 5, a2: 10, a3: 15);
            Assert.AreEqual(15, result1.ResultList.Count);
            Assert.AreEqual(Task06.Program.StopReason.FoundN, result1.StopReason);

            var result2 = Task06.Program.FindNElementsOrMElementsThatMultiply3(n: 15, m: 4, a1: 5, a2: 10, a3: 15);
            Assert.AreEqual(10, result2.ResultList.Count);
            Assert.AreEqual(Task06.Program.StopReason.FoundMThatMultiply3, result2.StopReason);

            var result3 = Task06.Program.FindNElementsOrMElementsThatMultiply3(n: 0, m: 1, a1: 5, a2: 10, a3: 15);
            Assert.AreEqual(0, result3.ResultList.Count);
            Assert.AreEqual(Task06.Program.StopReason.FoundN, result3.StopReason);
        }

        [Test]
        public void FindNElementsOrMElementsThatMultiply3ExceptionTest()
        {
            Assert.Throws<ArgumentException>(() =>
                Task06.Program.FindNElementsOrMElementsThatMultiply3(n: -1, m: 10, a1: 5, a2: 10, a3: 15));
            Assert.Throws<ArgumentException>(() =>
                Task06.Program.FindNElementsOrMElementsThatMultiply3(n: 10, m: -1, a1: 5, a2: 10, a3: 15));
        }

        #endregion

        #region Task07

        [Test]
        public void HuffmanTest()
        {
            var emptyArray = new int[0];

            Assert.AreEqual("", ToStringSortedSet(Task07.Program.HuffmanEncode(emptyArray)));

            Assert.AreEqual("0", ToStringSortedSet(Task07.Program.HuffmanEncode(new[] {2})));

            Assert.AreEqual("0 10", ToStringSortedSet(Task07.Program.HuffmanEncode(new[] {2, 3})));

            Assert.AreEqual("0 10 11", ToStringSortedSet(Task07.Program.HuffmanEncode(new[] {5, 6, 7})));

            Assert.AreEqual("0 100 101 11", ToStringSortedSet(Task07.Program.HuffmanEncode(new[] {5, 6, 7, 1})));

            Assert.AreEqual("000 001 01 10 11", ToStringSortedSet(Task07.Program.HuffmanEncode(new[] {5, 6, 7, 1, 2})));
        }

        [Test]
        public void HuffmanExceptionTest()
        {
            Assert.Throws<ArgumentException>(() => Task07.Program.HuffmanEncode(new []{5, 4, 3, -2, 0}));
        }

        private string ToStringSortedSet(SortedSet<string> set)
        {
            var result = "";
            foreach (var s in set) result += $"{s} ";
            return result.Trim();
        }

        #endregion

        #region Task08

        [Test]
        public void SearchFirstChainWithKDepthExceptionTest()
        {
            Assert.Throws<ArgumentException>(() => Task08.Program.SearchFirstChainWithKDepth(-1, new List<Edge>(), 15));
            Assert.Throws<ArgumentException>(() => Task08.Program.SearchFirstChainWithKDepth(15, new List<Edge>(), -1));
        }

        [Test]
        public void EdgeValidationTest()
        {
            const int k = 3;
            const int verticiesCount = 4;
            
            var edges1 = new List<Edge> { new Edge(-1, 3) };
            var edges2 = new List<Edge> { new Edge(2, -1) };
            var edges3 = new List<Edge> { new Edge(0, 1), new Edge(1, 2), new Edge(2, 10) };
            
            Assert.Throws<ArgumentException>(() => Task08.Program.SearchFirstChainWithKDepth(verticiesCount, edges1, k));
            Assert.Throws<ArgumentException>(() => Task08.Program.SearchFirstChainWithKDepth(verticiesCount, edges2, k));
            Assert.Throws<ArgumentException>(() => Task08.Program.SearchFirstChainWithKDepth(verticiesCount, edges3, k));
        }

        [Test]
        public void SearchFirstChainWithKDepthTest()
        {
            const int k1 = 2;
            const int k2 = 3;
            const int k3 = 5;
            const int verticiesCount = 4;
            var edges = new List<Edge>
            {
                new Edge(0, 1),
                new Edge(1, 2),
                new Edge(2, 3),
                new Edge(0, 3)
            };
            
            Assert.AreEqual("1-2", Task08.Program.SearchFirstChainWithKDepth(verticiesCount, edges, k1));
            Assert.AreEqual("1-2-3", Task08.Program.SearchFirstChainWithKDepth(verticiesCount, edges, k2));
            Assert.AreEqual(null, Task08.Program.SearchFirstChainWithKDepth(verticiesCount, edges, k3));
        }
        #endregion

        #region Task09

        [Test]
        public void AddTest()
        {
            var node = new Node();
            node.Data = -20;

            Assert.AreEqual("-20 -> null", node.ToString());

            node = node.Add(-10);
            Assert.AreEqual("-20 -> -10 -> null", node.ToString());

            node = node.Add(10);
            Assert.AreEqual("10 -> -20 -> -10 -> null", node.ToString());

            node = node.Add(0);
            Assert.AreEqual("10 -> 0 -> -20 -> -10 -> null", node.ToString());

            node = node.Add(15);
            Assert.AreEqual("15 -> 10 -> 0 -> -20 -> -10 -> null", node.ToString());

            node = node.Add(0);
            Assert.AreEqual("15 -> 10 -> 0 -> 0 -> -20 -> -10 -> null", node.ToString());
        }

        [Test]
        public void RemoveAtTest()
        {
            var node = new Node();
            node.Data = -20;
            node = node.Add(-10);
            node = node.Add(10);
            node = node.Add(0);
            node = node.Add(15);
            node = node.Add(0);

            Assert.Throws<ArgumentException>(() => node.RemoveAt(15));
            Assert.Throws<ArgumentException>(() => node.RemoveAt(-1));

            node = node.RemoveAt(0);
            Assert.AreEqual("10 -> 0 -> 0 -> -20 -> -10 -> null", node.ToString());

            node = node.RemoveAt(4);
            Assert.AreEqual("10 -> 0 -> 0 -> -20 -> null", node.ToString());

            node = node.RemoveAt(1);
            Assert.AreEqual("10 -> 0 -> -20 -> null", node.ToString());
        }

        [Test]
        public void IsExistTest()
        {
            var node = new Node();
            node.Data = -20;
            node = node.Add(-10);
            node = node.Add(10);
            node = node.Add(0);
            node = node.Add(15);

            Assert.AreEqual(true, node.IsExist(-10));
            Assert.AreEqual(true, node.IsExist(15));
            Assert.AreEqual(true, node.IsExist(10));
            Assert.AreEqual(false, node.IsExist(1));
        }

        [Test]
        public void GetAtTest()
        {
            var node = new Node();
            node.Data = -20;
            node = node.Add(-10);
            node = node.Add(10);
            node = node.Add(0);
            node = node.Add(15);

            Assert.AreEqual(15, node.GetAt(0).Data);
            Assert.AreEqual(-10, node.GetAt(node.Length - 1).Data);
            Assert.AreEqual(0, node.GetAt(2).Data);

            Assert.Throws<ArgumentException>(() => node.GetAt(10));
            Assert.Throws<ArgumentException>(() => node.GetAt(-1));
        }

        [Test]
        public void GetIndexOfTest()
        {
            var node = new Node();
            node.Data = -20;
            node = node.Add(-10);
            node = node.Add(10);
            node = node.Add(0);
            node = node.Add(15); // 15 10 0 -20 -10

            Assert.AreEqual(0, node.GetIndexOf(15));
            Assert.AreEqual(4, node.GetIndexOf(-10));
            Assert.AreEqual(1, node.GetIndexOf(10));
            Assert.AreEqual(-1, node.GetIndexOf(99));
        }

        #endregion

        #region Task11

        [Test]
        public void DecryptTest()
        {
            Assert.AreEqual("0", Task11.Program.Decrypt("000"));
            Assert.AreEqual("0", Task11.Program.Decrypt("001"));
            Assert.AreEqual("0", Task11.Program.Decrypt("010"));
            Assert.AreEqual("1", Task11.Program.Decrypt("011"));
            Assert.AreEqual("0", Task11.Program.Decrypt("100"));
            Assert.AreEqual("1", Task11.Program.Decrypt("101"));
            Assert.AreEqual("1", Task11.Program.Decrypt("111"));

            Assert.AreEqual("10", Task11.Program.Decrypt("110001"));
            Assert.AreEqual("100", Task11.Program.Decrypt("110001000"));
            Assert.AreEqual("110", Task11.Program.Decrypt("110011000"));
        }

        [Test]
        public void IncorrectDecryptTest()
        {
            Assert.Throws<NullReferenceException>(() => Task11.Program.Decrypt(null));
            Assert.Throws<ArgumentException>(() => Task11.Program.Decrypt(" "));
            Assert.Throws<ArgumentException>(() => Task11.Program.Decrypt("10"));
            Assert.Throws<ArgumentException>(() => Task11.Program.Decrypt("123"));
            Assert.Throws<ArgumentException>(() => Task11.Program.Decrypt("11100"));
            Assert.Throws<ArgumentException>(() => Task11.Program.Decrypt("111000115"));
        }

        #endregion
    }
}