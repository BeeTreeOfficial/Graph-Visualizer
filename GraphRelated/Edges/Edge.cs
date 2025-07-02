using Raylib_cs;
using DijkstraAlgorithm.GraphRelated.Points;
using System.Numerics;

namespace DijkstraAlgorithm.GraphRelated.Edges;

public class Edge(Point Left, Point Right)
{
    public Point left = Left;
    public Point right = Right;
    public Color color = Color.Red;
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
    public void Draw()
    {
        int X = ((int)Left.position.X + (int)Right.position.X) / 2;
        int Y = ((int)Left.position.Y + (int)Right.position.Y) / 2;
        Raylib.DrawLine((int)Left.position.X, (int)Left.position.Y, (int)Right.position.X, (int)Right.position.Y, color);
        Raylib.DrawText(Convert.ToString((int)Length), X, Y, 8, color);
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
