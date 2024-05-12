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
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			GamePlay gamePlay = new GamePlay();
			gamePlay.Show();
			this.Hide();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{
			GamePlay2 gamePlay2 = new GamePlay2();
			gamePlay2.Show();
			this.Hide();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Tutorial tutorial = new Tutorial();
			tutorial.Show();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
