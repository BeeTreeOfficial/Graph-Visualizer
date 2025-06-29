using Raylib_cs;
using System.Numerics;

namespace DijkstraAlgorithm;

public class Edge(Point Left, Point Right)
{
    public Point Left = Left;
    public Point Right = Right;

    public void Draw()
    {
        Raylib.DrawLine((int)Left.Position.X, (int)Left.Position.Y, (int)Right.Position.X, (int)Right.Position.Y, Color.Brown);
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
