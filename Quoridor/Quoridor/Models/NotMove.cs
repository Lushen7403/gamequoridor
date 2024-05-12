using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quoridor.Models
{
	internal class NotMove
	{
		public int colStart {  get; set; }
		public int rowStart { get; set; }
		public int colEnd { get; set; }
		public int rowEnd { get; set; }
		public NotMove(int colStart, int rowStart, int colEnd, int rowEnd)
		{
			this.colStart = colStart;
			this.rowStart = rowStart;
			this.colEnd = colEnd;
			this.rowEnd = rowEnd;
		}
		public NotMove() {
			this.colStart = -1;
			this.rowStart = -1;
				
			this.colEnd = -1;
			this.rowEnd = -1;
		}
	}
}
