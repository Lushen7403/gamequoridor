using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quoridor.Models
{
	internal class Player
	{
		public int Row { get; set; }
		public int Col { get; set; }
		public Color Color { get; set; }
		public bool isAI;
		public Player(int row, int col, Color color, bool isAI)
		{
			Row = row;
			Col = col;
			Color = color;
			this.isAI = isAI;
		}
	}
}
