using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Quoridor.Models
{
	internal class QuoridorGame
	{
		public const int MaxWall = 10;
		public int BoardSize { get; set; }
		public Dictionary<Player, int> wallsLeft { get; set; }
		public Player currentPlayer {  get; set; }
		public List<NotMove> listNotMove = new List<NotMove>();
		public List<Wall> walls = new List<Wall>();
		public Dictionary<Player, int> AI { get; set; }
		public QuoridorGame(int size)
		{
			BoardSize = size;
			wallsLeft = new Dictionary<Player, int>{
				{ new Player(0, BoardSize / 2, Color.Blue, false), MaxWall },
				{ new Player(BoardSize - 1, BoardSize / 2, Color.Green, false), MaxWall }
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
				&& p.colEnd == currentNode.Col && p.rowEnd == currentNode.Row) != null) )
			{
				return true;
			}
			return false;
		}
		private IEnumerable<Node> GetNeighbors(Node node)
		{
			var neighbors = new List<Node>();
			if(node.Col == 0 && node.Row != 0 && node.Row != 8)
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
			else if(node.Col == 0 && node.Row == 0)
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
	}
}
