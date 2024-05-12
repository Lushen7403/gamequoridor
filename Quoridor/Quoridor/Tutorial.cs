using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quoridor
{
	public partial class Tutorial : Form
	{
		public Tutorial()
		{
			InitializeComponent();
		}

		private void Tutorial_Load(object sender, EventArgs e)
		{
			textBox1.Text = "Quoridor được chơi trên 1 bàn cờ hình vuông kích thước 9x9. Mỗi người chơi có 1 quân cờ nằm ở trung tâm mỗi cạnh của bàn cờ (trong phiên bản 2 người chơi, các quân cờ sẽ được đặt đối diện nhau).\n" +
				"Mục đích của trò chơi là đưa quân cờ của mình đến 1 ô bất kì thuộc cạnh đối diện bàn cờ. Người chơi đến đích đầu tiên sẽ là người chiến thắng.\n" +
				"Trong Quoridor, tất cả người chơi sẽ có 20 bức tường. Tường có kích thước che chắn 2 ô vuông, được đặt thỏa mãn vào những đường ranh giới giữa các ô vuông trong bàn cờ.\n" +
				"Tường ngăn chặn đường đi giữa 2 ô có cạnh chung đặt nó bằng cách nhấn chuột phải vào giữa 2 ô có cạnh chung.\n" +
				"Khi bắt đầu 1 trò chơi mới, tất cả người chơi sẽ được chia đều 20 bức tường và một khi tường đã được đặt xuống bàn cờ thì nó sẽ không được nhấc lên hay di chuyển trong suốt trận đấu.\n" +
				"Mỗi lượt đi, mỗi người chơi hoặc là di chuyển quân cờ của mình, hoặc là đặt các bức tường xuống những vị trí hợp lệ.\n" +
				"Các quân cờ có thể di chuyển đến các ô vuông liền kề bằng cách nhấn đúp chuột theo các hướng dọc hoặc ngang mà giữa 2 ô đó không bị 1 bức tường nào che chắn.\n";
		}
	}
}
