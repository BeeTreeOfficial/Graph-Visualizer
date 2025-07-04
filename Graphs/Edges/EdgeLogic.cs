using Raylib_cs;
using DijkstraAlgorithm.Graphs.Points;
using System.Numerics;

namespace DijkstraAlgorithm.Graphs.Edges;

public partial class Edge
{
    public Edge(Point Left, Point Right)
    {
        this.left = Left;
        this.right = Right;
    }
    public Point left;
    public Point right;
    public Point Left
    {
        get { return left; }
        set { left = value; }
    }
    public Point Right
    {
        get { return right; }
        set { right = value; }
    }

    public void DetachFromBothPoints()
    {
        Left.ConnectedEdges.Remove(Right.Name);
        Right.ConnectedEdges.Remove(Left.Name);
    }

    public Point GetPointOppositeTo(Point CurrentPoint)
    {
        bool IsLeft = Left == CurrentPoint;
        bool IsRight = Right == CurrentPoint;
        if (IsLeft)
        {
            return Right;
        }
        if (IsRight)
        {
            return Left;
        }
        throw new ArgumentException("Point is not part of this edge");
    }

    public float Length { get { return Math.Abs(Vector2.Distance(Right.position, Left.position)); } }


}
