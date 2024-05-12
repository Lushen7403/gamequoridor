using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Quoridor.Models;
using Orientation = Quoridor.Models.Orientation;

namespace Quoridor
{
	public partial class GamePlay : Form
	{
		private QuoridorGame game;
		private int cellSize = 40;
		private int padding = 10;
		private int targetRow, targetCol;
		private bool isMoving = false;

		public GamePlay()
		{
			try
			{
				InitializeComponent();
				game = new QuoridorGame(9); // Kích thước bàn cờ 9x9
				this.DoubleBuffered = true;
				panelBoard.Paint += panelBoard_Paint;
				panelBoard.MouseDoubleClick += panelBoard_DoubleMouseClick;
				panelBoard.MouseDown += panelBoard_MouseDown;
				panel1.Paint += panel1_Paint;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi: " + ex.Message);
			}
		}

		private void GamePlay_Load(object sender, EventArgs e)
		{

		}
		private void panel1_Paint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			SolidBrush circleBrush = new SolidBrush(game.currentPlayer.Color);
			g.FillRectangle(circleBrush, 200, 10, 20, 20);
			g.FillRectangle(Brushes.Green, 240, 35, 15, 15);
			g.FillRectangle(Brushes.Blue, 240, 55, 15, 15);

		}
		private void panelBoard_Paint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			DrawBoard(g);
			DrawPlayers(g);
			DrawWalls(g);
		}
		// vẽ người chơi, bàn cờ, tường
		private void DrawBoard(Graphics g)
		{
			for (int row = 0; row < game.BoardSize; row++)
			{
				for (int col = 0; col < game.BoardSize; col++)
				{
					int x = padding + col * (cellSize + 5);
					int y = padding + row * (cellSize + 5);
					if ((col + row) % 2 == 0)
					{
						g.DrawRectangle(Pens.Black, x, y, cellSize, cellSize);
					}
					else
					{
						g.FillRectangle(Brushes.Gray, x, y, cellSize, cellSize);
					}
				}
			}
			g.DrawRectangle(Pens.Red, 300, 800, cellSize, cellSize);
		}
		private void DrawWalls(Graphics g)
		{
			Pen wallPen = new Pen(Color.Red, 2);
			SolidBrush redBrush = new SolidBrush(Color.Red);
			foreach (var wall in game.walls)
			{

				if (wall.Orientation == Orientation.Horizontal)
				{
					g.FillRectangle(redBrush, wall.xStart, wall.yStart, 85, 5);
				}
				else
				{
					g.FillRectangle(redBrush, wall.xStart, wall.yStart, 5, 85);
				}

			}
			wallPen.Dispose();
		}
		private void DrawPlayers(Graphics g)
		{
			foreach (var player in game.wallsLeft.Keys)
			{
				int x = padding + player.Col * (cellSize + 5) + cellSize / 4;
				int y = padding + player.Row * (cellSize + 5) + cellSize / 4;
				int size = cellSize / 2;
				SolidBrush myBrush = new SolidBrush(player.Color);
				g.FillEllipse(myBrush, x, y, size, size);
			}

		}

		// di chuyển người chơi
		private void panelBoard_DoubleMouseClick(object sender, MouseEventArgs e)
		{
			if (!isMoving)
			{
				int clickedCol = (e.X - padding) / (cellSize + 5);
				int clickedRow = (e.Y - padding) / (cellSize + 5);
				if (game.listNotMove.FirstOrDefault(p => p.colEnd == clickedCol && p.rowEnd == clickedRow
				&& p.colStart == game.currentPlayer.Col && p.rowStart == game.currentPlayer.Row) == null)
				{
					if(clickedCol >= 0 && clickedCol <=8 && clickedRow >=0 && clickedCol <=8)
					{
						if (IsValidMove(clickedRow, clickedCol))
						{
							isMoving = true;
							targetRow = clickedRow;
							targetCol = clickedCol;
							MovePlayer();
						}
					}
					
				}

			}
		}
		private bool IsValidMove(int newRow, int newCol)
		{
			foreach (var player in game.wallsLeft.Keys)
			{
				if (player.Row == newRow && player.Col == newCol)
				{
					return false; // Không hợp lệ nếu ô đó chứa người chơi còn lại
				}
			}
			if (newRow == game.currentPlayer.Row && Math.Abs(newCol - game.currentPlayer.Col) == 1)
			{
				return true;
			}
			else if (newCol == game.currentPlayer.Col && Math.Abs(newRow - game.currentPlayer.Row) == 1)
			{
				return true;
			}
			else return false;
		}
		private void MovePlayer()
		{
			if (isMoving && IsValidMove(targetRow, targetCol))
			{
				game.currentPlayer.Row = targetRow;
				game.currentPlayer.Col = targetCol;
				panelBoard.Invalidate();
				panel1.Invalidate();
				//MessageBox.Show($"{targetCol} {targetRow}");
				// Đổi lượt chơi sau khi người chơi di chuyển thành công
				game.ChangeTurn();

				isMoving = false; // Kết thúc quá trình di chuyển
				CheckGameOver();
			}
		}


		// đặt tường
		private void AddToNotMove(Wall wall)
		{
			int col = wall.xStart / (cellSize + 5);
			int row = wall.yStart / (cellSize + 5);
			if (wall.Orientation == Orientation.Horizontal)
			{
				NotMove a1 = new NotMove(col, row, col, row - 1);
				NotMove a2 = new NotMove(col, row - 1, col, row);
				NotMove a3 = new NotMove(col + 1, row, col + 1, row - 1);
				NotMove a4 = new NotMove(col + 1, row - 1, col + 1, row);
				game.listNotMove.Add(a1); game.listNotMove.Add(a2);
				game.listNotMove.Add(a3); game.listNotMove.Add(a4);
			}
			if (wall.Orientation == Orientation.Vertical)
			{
				NotMove a1 = new NotMove(col - 1, row, col, row);
				NotMove a2 = new NotMove(col, row, col - 1, row);
				NotMove a3 = new NotMove(col, row + 1, col - 1, row + 1);
				NotMove a4 = new NotMove(col - 1, row + 1, col, row + 1);
				game.listNotMove.Add(a1); game.listNotMove.Add(a2);
				game.listNotMove.Add(a3); game.listNotMove.Add(a4);
			}
		}
		private bool IsValidPlaceWall(Wall wall)
		{
			bool bool1, bool2;
			switch (wall.Orientation)
			{
				case Orientation.Horizontal:
					if (wall.xStart > 7 * (cellSize + 5) + padding || wall.xStart < 0
						|| wall.yStart < cellSize + 5 || wall.yStart > 9 * (cellSize + 5)) bool1 = false;
					else bool1 = true;
					break;
				default:
					if (wall.yStart > 7 * (cellSize + 5) + padding || wall.yStart < 0
						|| wall.xStart < cellSize + 5 || wall.xStart > 9 * (cellSize + 5)) bool1 = false;
					else bool1 = true;
					break;
			}

			switch (wall.Orientation)
			{
				case Orientation.Horizontal:
					if (game.walls.Where(x => x.Orientation == Orientation.Horizontal)
					.Where(p => p.yStart == wall.yStart)
					.FirstOrDefault(x => Math.Abs(x.xStart - wall.xStart) < cellSize + 5 + padding) != null) bool2 = false;
					else bool2 = true;
					break;
				default:
					if (game.walls.Where(x => x.Orientation == Orientation.Vertical)
					.Where(p => p.xStart == wall.xStart)
					.FirstOrDefault(x => Math.Abs(x.yStart - wall.yStart) < cellSize + 5 + padding) != null) bool2 = false;
					else bool2 = true;
					break;
			}
			if (bool1 && bool2)
			{
				return true;
			}
			else return false;
		}
		private void panelBoard_MouseDown(object sender, MouseEventArgs e)
		{
			int cellCol, cellRow;
			int xStart, yStart, xEnd, yEnd;
			Wall wall;
			if (e.Button == MouseButtons.Right)
			{
				if (rbHorWall.Checked)
				{
					if (game.wallsLeft[game.currentPlayer] > 0)
					{
						if ((e.X - padding) % (cellSize + 5) < (cellSize + 5) / 2)
						{
							cellCol = (e.X - padding) / (cellSize + 5) - 1;
						}
						else cellCol = (e.X - padding) / (cellSize + 5);
						if ((e.Y - padding) % (cellSize + 5) < (cellSize + 5) / 2)
						{
							cellRow = (e.Y - padding) / (cellSize + 5) - 1;
						}
						else cellRow = (e.Y - padding) / (cellSize + 5);

						xStart = (cellCol) * (cellSize + 5) + padding;
						yStart = (cellRow + 1) * (cellSize + 5) + padding / 2;
						//xEnd = (cellCol + 1) * cellSize;
						//yEnd = cellRow * cellSize;
						wall = new Wall(xStart, yStart, orientation: Models.Orientation.Horizontal);
						if (IsValidPlaceWall(wall))
						{
							game.walls.Add(wall);
							AddToNotMove(wall);
							bool a = game.HasPath(game.currentPlayer.Col, game.currentPlayer.Row, game.GetWinRow(game.currentPlayer));
							game.ChangeTurn();
							bool b = game.HasPath(game.currentPlayer.Col, game.currentPlayer.Row, game.GetWinRow(game.currentPlayer));
							game.ChangeTurn();
							if(!a || !b)
							{
								game.walls.Remove(wall);
								game.listNotMove.RemoveRange(game.listNotMove.Count - 4, 4);
								MessageBox.Show("Nước đi không hợp lệ !!");
							}
							game.wallsLeft[game.currentPlayer]--;
							panelBoard.Invalidate();

							if (game.currentPlayer.Color == Color.Green)
							{
								label1.Text = $"{game.wallsLeft[game.currentPlayer]}";
							}
							else
							{
								label2.Text = $"{game.wallsLeft[game.currentPlayer]}";
							}
							panel1.Invalidate();
							game.ChangeTurn();
						}
						else MessageBox.Show("Nước đi không hợp lệ !!");
					}
					else MessageBox.Show("Không còn tường để đặt");
				}
				if (rbVerWall.Checked)
				{
					if (game.wallsLeft[game.currentPlayer] > 0)
					{
						if ((e.X - padding) % (cellSize + 5) < (cellSize + 5) / 2)
						{
							cellCol = (e.X - padding) / (cellSize + 5) - 1;
						}
						else cellCol = (e.X - padding) / (cellSize + 5);
						if ((e.Y - padding) % (cellSize + 5) < (cellSize + 5) / 2)
						{
							cellRow = (e.Y - padding) / (cellSize + 5) - 1;
						}
						else cellRow = (e.Y - padding) / (cellSize + 5);
						xStart = (cellCol + 1) * (cellSize + 5) + padding / 2;
						yStart = (cellRow) * (cellSize + 5) + padding;
						//xEnd = cellCol * cellSize;
						//yEnd = (cellRow + 1) * cellSize;
						wall = new Wall(xStart, yStart, orientation: Models.Orientation.Vertical);
						if (IsValidPlaceWall(wall))
						{
							game.walls.Add(wall);
							AddToNotMove(wall);
							bool a = game.HasPath(game.currentPlayer.Col, game.currentPlayer.Row, game.GetWinRow(game.currentPlayer));
							game.ChangeTurn();
							bool b = game.HasPath(game.currentPlayer.Col, game.currentPlayer.Row, game.GetWinRow(game.currentPlayer));
							game.ChangeTurn();
							if (!a || !b)
							{
								game.walls.Remove(wall);
								game.listNotMove.RemoveRange(game.listNotMove.Count - 4, 4);
								MessageBox.Show("Nước đi không hợp lệ !!");
							}
							game.wallsLeft[game.currentPlayer]--;
							panelBoard.Invalidate();
							if (game.currentPlayer.Color == Color.Green)
							{
								label1.Text = $"{game.wallsLeft[game.currentPlayer]}";
							}
							else
							{
								label2.Text = $"{game.wallsLeft[game.currentPlayer]}";
							}
							panel1.Invalidate();
							game.ChangeTurn();
						}
						else MessageBox.Show("Nước đi không hợp lệ !!");
					}
					else MessageBox.Show("Không còn tường để đặt");
				}
			}
		}

		private void CheckGameOver()
		{
			Player winner = game.CheckWin();
			if (winner != null)
			{
				string message = $"Người chơi {winner.Color} chiến thắng!";
				MessageBox.Show(message, "Chiến thắng", MessageBoxButtons.OK, MessageBoxIcon.Information);
				game = new QuoridorGame(9);
				panelBoard.Invalidate();
				panel1.Invalidate();
				// Reset trò chơi sau khi có người chiến thắng
			}
		}





		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void rbHorWall_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			Form1 gamePlay = new Form1();
			gamePlay.Show();
			this.Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Tutorial tutorial = new Tutorial();
			tutorial.Show();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void panelBoard_Paint_1(object sender, PaintEventArgs e)
		{

		}
	}
}
