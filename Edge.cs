using Raylib_cs;
using System.Numerics;

namespace DijkstraAlgorithm;

public class Edge(Point Left, Point Right)
{
    public Point Left = Left;
    public Point Right = Right;
    public Color color = Color.Red;

    public void Draw()
    {
        int X = ((int)Left.Position.X + (int)Right.Position.X) / 2;
        int Y = ((int)Left.Position.Y + (int)Right.Position.Y) / 2;
        Raylib.DrawLine((int)Left.Position.X, (int)Left.Position.Y, (int)Right.Position.X, (int)Right.Position.Y, color);
        Raylib.DrawText(Convert.ToString((int)Length), X, Y, 8, color);
    }

    public void DetachFromBothPoints()
    {
        Left.ConnectedEdges.Remove(Right.Name);
        Right.ConnectedEdges.Remove(Left.Name);
    }

    public Point GetPointOppositeTo(Point CurrentPoint)
    {
        bool IsLeft = (Left == CurrentPoint);
        bool IsRight = (Right == CurrentPoint);
        if (IsLeft)
        {
            return Right;
        }
        if (IsRight)
        {
            return Left;
        }
        Console.WriteLine("How the fuck did you get There?");
        return Left;
    }

    public float Length { get { return Math.Abs(Vector2.Distance(Right.Position, Left.Position)); } }


}
