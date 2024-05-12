using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quoridor.Models
{
	internal class Wall
	{
		public int xStart { get; set; }
		public int yStart { get; set; }
		public Orientation Orientation { get; set; }

		public Wall(int xstart, int ystart, Orientation orientation)
		{
			xStart = xstart;
			yStart = ystart;
			Orientation = orientation;
		}
	}
	public enum Orientation
	{
		Horizontal,
		Vertical
	}
}
