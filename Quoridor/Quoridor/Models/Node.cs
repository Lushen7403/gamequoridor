using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quoridor.Models
{
	internal class Node
	{
		public int Col { get; }
		public int Row { get; }
		public double HCost { get; set; }
		public double FCost { get; set; }
		public Node Parent { get; set; }
		public List<Node> Neighbors { get; }

		public Node(int col, int row)
		{
			Col = col;
			Row = row;
			Neighbors = new List<Node>();
			FCost = 0;
			HCost = 0;
		}
	}
}
