using Raylib_cs;
using DijkstraAlgorithm.Graphs.Points;
using System.Numerics;

namespace DijkstraAlgorithm.Graphs.Edges;

public partial class Edge
{
	public Edge(Point Left, Point Right)
	{
		this.Left = Left;
		this.Right = Right;
	}
	public Point Left { get; private set; }
	public Point Right { get; private set; }

	public void DetachFromBothPoints()
	{
		Left.ConnectedEdges.Remove(Right.Name);
		Right.ConnectedEdges.Remove(Left.Name);
	}

	public Point GetPointOppositeTo(Point CurrentPoint)
	{
		if (Left == CurrentPoint) return Right;
		if (Right == CurrentPoint) return Left;
		throw new ArgumentException("Point is not part of this edge");
	}
	public float Length { get { return Math.Abs(Vector2.Distance(Right.Position, Left.Position) / 2); } }
}
