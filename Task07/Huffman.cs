using System;
using System.Collections.Generic;
using System.Linq;

namespace Task07
{
	public static class Huffman
	{
		private static HuffmanTree Root { get; set; }
		private static List<HuffmanTree> HuffmanTrees { get; set; }
		private static HuffmanTree[] Nodes { get; set; }
		
		public static SortedSet<string> Encode(string input)
		{
			HuffmanTrees = input
				.GroupBy(c => c)
				.Select(o => new HuffmanTree(o.Key, o.Count()))
				.OrderBy(n => n.Frequency)
				.ThenBy(n => n.Character).ToList();
			Nodes = HuffmanTrees.ToArray<HuffmanTree>();

			BuildTree();
			Traverse(Root, 1);

			var set = new SortedSet<string>();
			foreach (var c in input)
			{
				var code = Array.Find(Nodes, n => n.Character == c).Binary;
				set.Add(code);
			}

			return set;
		}
		
		private static void BuildTree()
		{
			HuffmanTrees.Sort();
			while (HuffmanTrees.Count > 1)
			{
				var parent = new HuffmanTree();
				if (HuffmanTrees[0].Frequency > HuffmanTrees[1].Frequency)
					HuffmanTrees.Sort();
				var min = HuffmanTrees[0];
				var secondMin = HuffmanTrees[1];

				if (parent.LeftChild == null)
				{
					parent.LeftChild = min;
					min.Parent = parent;
					HuffmanTrees.Remove(min);
				}
				if (parent.RightChild == null)
				{
					parent.RightChild = secondMin;
					secondMin.Parent = parent;
					HuffmanTrees.Remove(secondMin);
				}

				parent.Frequency = min.Frequency + secondMin.Frequency;
				HuffmanTrees.Insert(0, parent);
			}
			
			if (HuffmanTrees != null || HuffmanTrees[0].Parent == null) Root = HuffmanTrees[0];
		}

		private static void Traverse(HuffmanTree huffmanTree, int pos)
		{
			// Терминальный случай
			if (huffmanTree.IsLeaf())
			{
				huffmanTree.Logical = pos;
				huffmanTree.Binary = Convert.ToString(huffmanTree.Logical, 2).Substring(huffmanTree.Parent == null ? 0 : 1);
				return;
			}

			Traverse(huffmanTree.LeftChild, pos * 2);
			Traverse(huffmanTree.RightChild, pos * 2 + 1);
		}
	}

	class HuffmanTree : IComparable<HuffmanTree>
	{
		// PROPERTIES
		public readonly char? Character;
		public int? Frequency { get; set; }
		public string Binary { get; set; }
		public int Logical { get; set; }
		public HuffmanTree LeftChild { get; set; }
		public HuffmanTree RightChild { get; set; }
		public HuffmanTree Parent { get; set; }

		public HuffmanTree() { }
		
		public HuffmanTree(char character, int frequency)
		{
			Character = character;
			Frequency = frequency;
			LeftChild = null;
			RightChild = null;
			Parent = null;
		}
		
		public bool IsLeaf()
		{
			return this.LeftChild == null && this.RightChild == null;
		}

		public int CompareTo(HuffmanTree other)
		{
			return this.Frequency == other.Frequency ? 0 : this.Frequency < other.Frequency ? -1 : 1;
		}

		public override string ToString()
		{
			return $"Character: {Character}\nFrequency: {Frequency}\nBinary: {Binary}\nLogical: {Logical}";
		}
	}
}