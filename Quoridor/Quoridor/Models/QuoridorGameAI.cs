using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Quoridor.Models
{
	internal class QuoridorGameAI
	{
		public const int MaxWall = 10;
		public int BoardSize { get; set; }
		public Dictionary<Player, int> wallsLeft { get; set; }
		public Player currentPlayer { get; set; }
		public List<NotMove> listNotMove = new List<NotMove>();
		public List<Wall> walls = new List<Wall>();
		public Dictionary<Player, int> AI { get; set; }
		public QuoridorGameAI(int size)
		{
			BoardSize = size;
			wallsLeft = new Dictionary<Player, int>{
				{ new Player(0, BoardSize / 2, Color.Blue, false), MaxWall },
				{ new Player(BoardSize - 1, BoardSize / 2, Color.Green, true), MaxWall }
			};
			currentPlayer = wallsLeft.Keys.First();
		}
		public void ChangeTurn()
		{
			int currentIndex = GetPlayerIndex(currentPlayer);
			currentIndex = (currentIndex + 1) % wallsLeft.Count;
			currentPlayer = wallsLeft.Keys.ElementAt(currentIndex);
		}

		private int GetPlayerIndex(Player player)
		{
			int index = 0;
			foreach (var kvp in wallsLeft)
			{
				if (kvp.Key == player)
				{
					return index;
				}
				index++;
			}
			return -1; // Không tìm thấy
		}
		public Player CheckWin()
		{
			foreach (var player in wallsLeft.Keys)
			{
				if (player == wallsLeft.Keys.ElementAt(0) && player.Row == BoardSize - 1)
				{
					// Người chơi 0 (Blue) đến hàng cuối cùng
					return player;
				}
				else if (player == wallsLeft.Keys.ElementAt(1) && player.Row == 0)
				{
					// Người chơi 1 (Green) đến hàng đầu tiên
					return player;
				}
			}
			return null;
		}

		public int GetWinRow(Player player)
		{
			if (player.Color == Color.Blue)
			{
				// Nếu là người chơi màu Blue, WinRow là hàng cuối cùng (BoardSize - 1)
				return BoardSize - 1;
			}
			else
			{
				// Ngược lại, WinRow là hàng đầu tiên (0)
				return 0;
			}
		}

		public bool HasPath(int colStart, int rowStart, int winRow)
		{
			var openSet = new HashSet<Node>();
			var closedSet = new HashSet<Node>();
			var startNode = new Node(colStart, rowStart);

			// Lặp qua tất cả các cột để tạo các endNode và tìm đường đi từ start đến các ô trong hàng winRow
			for (int col = 0; col < BoardSize; col++)
			{
				var endNode = new Node(col, winRow);
				openSet.Add(startNode);

				while (openSet.Count > 0)
				{
					var currentNode = openSet.First();

					if (currentNode.Row == endNode.Row && currentNode.Col == endNode.Col)
					{
						return true;
					}


					foreach (var neighbor in GetNeighbors(currentNode))
					{
						if (!IsNeighborInListNotMove(currentNode, neighbor)
							&& openSet.FirstOrDefault(p => p.Col == neighbor.Col && p.Row == neighbor.Row) == null
							&& closedSet.FirstOrDefault(p => p.Col == neighbor.Col && p.Row == neighbor.Row) == null)
						{
							neighbor.Parent = currentNode;
							openSet.Add(neighbor);
						}
					}
					openSet.Remove(currentNode);
					closedSet.Add(currentNode);
				}

				// Đánh dấu là đã kiểm tra xong một cột
				openSet.Clear();
				closedSet.Clear();
			}

			// Không tồn tại đường đi đến các ô trong hàng winRow
			return false;
		}
		private bool IsNeighborInListNotMove(Node currentNode, Node neighbor)
		{
			if ((listNotMove.FirstOrDefault(p => p.colEnd == neighbor.Col && p.rowEnd == neighbor.Row
				&& p.colStart == currentNode.Col && p.rowStart == currentNode.Row) != null)
				&& (listNotMove.FirstOrDefault(p => p.colStart == neighbor.Col && p.rowStart == neighbor.Row
				&& p.colEnd == currentNode.Col && p.rowEnd == currentNode.Row) != null))
			{
				return true;
			}
			return false;
		}
		private IEnumerable<Node> GetNeighbors(Node node)
		{
			var neighbors = new List<Node>();
			if (node.Col == 0 && node.Row != 0 && node.Row != 8)
			{
				neighbors.Add(new Node(node.Col, node.Row + 1));
				neighbors.Add(new Node(node.Col, node.Row - 1));
				neighbors.Add(new Node(node.Col + 1, node.Row));
				return neighbors;
			}
			else if (node.Col == 8 && node.Row != 0 && node.Row != 8)
			{
				neighbors.Add(new Node(node.Col, node.Row + 1));
				neighbors.Add(new Node(node.Col, node.Row - 1));
				neighbors.Add(new Node(node.Col - 1, node.Row));
				return neighbors;
			}
			else if (node.Row == 0 && node.Col != 0 && node.Col != 8)
			{
				neighbors.Add(new Node(node.Col + 1, node.Row));
				neighbors.Add(new Node(node.Col - 1, node.Row));
				neighbors.Add(new Node(node.Col, node.Row + 1));
				return neighbors;
			}
			else if (node.Row == 8 && node.Col != 0 && node.Col != 8)
			{
				neighbors.Add(new Node(node.Col + 1, node.Row));
				neighbors.Add(new Node(node.Col - 1, node.Row));
				neighbors.Add(new Node(node.Col, node.Row - 1));
				return neighbors;
			}
			else if (node.Col == 0 && node.Row == 0)
			{
				neighbors.Add(new Node(node.Col + 1, node.Row));
				neighbors.Add(new Node(node.Col, node.Row + 1));
				return neighbors;
			}
			else if (node.Col == 0 && node.Row == 8)
			{
				neighbors.Add(new Node(node.Col + 1, node.Row));
				neighbors.Add(new Node(node.Col, node.Row - 1));
				return neighbors;
			}
			else if (node.Col == 8 && node.Row == 8)
			{
				neighbors.Add(new Node(node.Col - 1, node.Row));
				neighbors.Add(new Node(node.Col, node.Row - 1));
				return neighbors;
			}
			else if (node.Col == 8 && node.Row == 0)
			{
				neighbors.Add(new Node(node.Col - 1, node.Row));
				neighbors.Add(new Node(node.Col, node.Row + 1));
				return neighbors;
			}
			else
			{
				neighbors.Add(new Node(node.Col, node.Row + 1));
				neighbors.Add(new Node(node.Col, node.Row - 1));
				neighbors.Add(new Node(node.Col + 1, node.Row));
				neighbors.Add(new Node(node.Col - 1, node.Row));
				return neighbors;
			}
		}

		private List<(int col, int row)> RetracePath(Node startNode, Node endNode)
		{
			var path = new List<(int col, int row)>();
			var currentNode = endNode;

			while (currentNode != startNode)
			{
				path.Add((currentNode.Col, currentNode.Row));
				currentNode = currentNode.Parent;
			}

			path.Reverse();
			return path;
		}
		public Tuple<double, List<(int col, int row)>> FindShortestPath(int colStart, int rowStart, int winRow)
		{
			List<Tuple<double, List<(int col, int row)>>> list = new List<Tuple<double, List<(int col, int row)>>>();
			var openSet = new HashSet<Node>();
			var closedSet = new HashSet<Node>();
			var startNode = new Node(colStart, rowStart);
			for (int col = 0; col < BoardSize; col++)
			{
				var endNode = new Node(col, winRow);
				openSet.Add(startNode);

				while (openSet.Count > 0)
				{
					var currentNode = openSet.OrderBy(p => p.FCost).First();

					if (currentNode.Row == endNode.Row && currentNode.Col == endNode.Col)
					{
						list.Add(new Tuple<double, List<(int col, int row)>>(currentNode.FCost, RetracePath(startNode, currentNode)));
					}
					foreach (var neighbor in GetNeighbors(currentNode))
					{
						if (!IsNeighborInListNotMove(currentNode, neighbor)
							&& openSet.FirstOrDefault(p => p.Col == neighbor.Col && p.Row == neighbor.Row) == null
							&& closedSet.FirstOrDefault(p => p.Col == neighbor.Col && p.Row == neighbor.Row) == null)
						{
							int HCost = GetHCost(neighbor, endNode);
							neighbor.FCost = currentNode.FCost + HCost + 1;
							neighbor.Parent = currentNode;
							openSet.Add(neighbor);
						}
					}
					openSet.Remove(currentNode);
					closedSet.Add(currentNode);
				}
				// Đánh dấu là đã kiểm tra xong một cột
				openSet.Clear();
				closedSet.Clear();
			}
			return list.OrderBy(p => p.Item1).First();
		}
		private int GetHCost(Node node, Node endNode)
		{
			// Tính khoảng cách Manhattan giữa node và endNode
			int hCost = Math.Abs(node.Col - endNode.Col) + Math.Abs(node.Row - endNode.Row);
			return hCost;
		}
		public void MoveAI()
		{
			if (currentPlayer.isAI == true)
			{
				var path = FindShortestPath(currentPlayer.Col, currentPlayer.Row, GetWinRow(currentPlayer));
				List<(int col, int row)> shortestPath = path.Item2;
				var a = shortestPath.First();
				bool p = true;
				foreach (var player in wallsLeft.Keys)
				{
					if(a.col == player.Col && a.row == player.Row)
					{
						p = false;
					}
				}
				if(p)
				{
					if (a.col >= 0 && a.col < 9 && a.row >= 0 && a.row < 9)
					{
						currentPlayer.Col = a.col;
						currentPlayer.Row = a.row;
					}
				}
				else
				{
					currentPlayer.Col++;
				}
				
			}
		}
		public void AIDecision()
		{
			if (currentPlayer.isAI == true)
			{
				double maxPath;
				var pathAI = FindShortestPath(currentPlayer.Col, currentPlayer.Row, GetWinRow(currentPlayer));
				ChangeTurn();
				var path = FindShortestPath(currentPlayer.Col, currentPlayer.Row, GetWinRow(currentPlayer));
				maxPath = path.Item1;
				ChangeTurn();
				NotMove x1 = new NotMove();
				NotMove x2 = new NotMove();
				NotMove x3 = new NotMove();
				NotMove x4 = new NotMove();
				if (pathAI.Item1 < path.Item1 + 3 && wallsLeft[currentPlayer] > 0 )
				{
					for (int col = 0; col < 8; col++)
					{
						for (int row = 0; row < 8; row++)
						{
							NotMove a1 = new NotMove();
							NotMove a2 = new NotMove();
							NotMove a3 = new NotMove();
							NotMove a4 = new NotMove();
							NotMove b1 = new NotMove();
							NotMove b2 = new NotMove();
							NotMove b3 = new NotMove();
							NotMove b4 = new NotMove();
							double length1 = 0, length2 = 0;
							if (CanPlaceWall(col, row, col + 1, row, col, row + 1, col + 1, row + 1))
							{
								// thêm tường vào bản đồ
								a1 = new NotMove(col, row, col + 1, row);
								a2 = new NotMove(col + 1, row, col, row);
								a3 = new NotMove(col, row + 1, col + 1, row + 1);
								a4 = new NotMove(col + 1, row + 1, col, row + 1);
								listNotMove.Add(a1); listNotMove.Add(a2); listNotMove.Add(a3); listNotMove.Add(a4);
								bool a = HasPath(currentPlayer.Col, currentPlayer.Row, GetWinRow(currentPlayer));
								ChangeTurn();
								// current = nguoi choi
								bool b = HasPath(currentPlayer.Col, currentPlayer.Row, GetWinRow(currentPlayer));
								if (!a || !b)
								{
									listNotMove.RemoveRange(listNotMove.Count - 4, 4);
									ChangeTurn();
								}
								else
								{
									var result = FindShortestPath(currentPlayer.Col, currentPlayer.Row, GetWinRow(currentPlayer));
									ChangeTurn();
									length1 = result.Item1;
									listNotMove.RemoveRange(listNotMove.Count - 4, 4);
								}
							}
							if (CanPlaceWall(col, row, col, row + 1, col + 1, row, col + 1, row + 1))
							{
								b1 = new NotMove(col, row, col, row + 1);
								b2 = new NotMove(col, row + 1, col, row);
								b3 = new NotMove(col + 1, row, col + 1, row + 1);
								b4 = new NotMove(col + 1, row + 1, col + 1, row);
								listNotMove.Add(b1); listNotMove.Add(b2); listNotMove.Add(b3); listNotMove.Add(b4);
								bool a = HasPath(currentPlayer.Col, currentPlayer.Row, GetWinRow(currentPlayer));
								ChangeTurn();
								// current = nguoi choi
								bool b = HasPath(currentPlayer.Col, currentPlayer.Row, GetWinRow(currentPlayer));
								if (!a || !b)
								{
									listNotMove.RemoveRange(listNotMove.Count - 4, 4);
									ChangeTurn();
								}
								else
								{
									var result = FindShortestPath(currentPlayer.Col, currentPlayer.Row, GetWinRow(currentPlayer));
									ChangeTurn();
									length2 = result.Item1;
									listNotMove.RemoveRange(listNotMove.Count - 4, 4);
								}
							}
							if (length1 < length2)
							{
								if (length2 > maxPath)
								{
									maxPath = length2;
									x1 = b1; x2 = b2; x3 = b3; x4 = b4;
								}
							}
							else
							{
								if (length1 > maxPath)
								{
									maxPath = length1;
									x1 = a1; x2 = a2; x3 = a3; x4 = a4;
								}
							}
						}
					}
					if (x1.colStart > -1 && x2.colStart > -1 && x3.colStart > -1 && x4.colStart > -1)
					{
						listNotMove.Add(x1); listNotMove.Add(x2); 
						listNotMove.Add(x3); listNotMove.Add(x4);
						if (x1.colStart == x2.colStart && x1.colEnd == x2.colEnd)
						{
							Wall wall = new Wall(x2.colStart * 45 + 10, x2.rowStart * 45 + 5, Orientation.Horizontal);
							walls.Add(wall);
							wallsLeft[currentPlayer]--;
						}
						if (x1.rowStart == x2.rowStart && x1.rowEnd == x2.rowEnd)
						{
							Wall wall = new Wall(x2.colStart * 45 + 5, x2.rowStart * 45 + 10, Orientation.Vertical);
							walls.Add(wall);
							wallsLeft[currentPlayer]--;
						}
					}
					else
					{
						MoveAI();
					}
				}
				else
				{
					MoveAI();
				}
				
			}
		}
		private bool CanPlaceWall(int colStart, int rowStart, int colEnd, int rowEnd, int colStart2, int rowStart2, int colEnd2, int rowEnd2)
		{
			var a = listNotMove.FirstOrDefault(p => p.colStart == colStart && p.rowStart == rowStart
			&& p.colEnd == colEnd && p.rowEnd == rowEnd);
			var b = listNotMove.FirstOrDefault(p => p.colStart == colEnd && p.rowStart == rowEnd
			&& p.colEnd == colStart && p.rowEnd == rowStart);
			var c = listNotMove.FirstOrDefault(p => p.colStart == colStart2 && p.rowStart == rowStart2
			&& p.colEnd == colEnd2 && p.rowEnd == rowEnd2);
			var d = listNotMove.FirstOrDefault(p => p.colStart == colEnd2 && p.rowStart == rowEnd2
			&& p.colEnd == colStart2 && p.rowEnd == rowStart2);
			if (a == null && b == null && c == null && d == null)
			{
				return true;
			}
			return false;
		}
	}
}
