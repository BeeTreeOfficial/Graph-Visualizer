
using Raylib_cs;

namespace DijkstraAlgorithm.Graphs.Points;

public partial class Point
{
    public Color color = Color.Red;
    public Color Color { get; }
    public void DrawHighlight()
    {
        Raylib.DrawCircleLines((int)position.X, (int)position.Y, 15, color);
    }
    public void Draw()
    {
        Raylib.DrawCircle((int)position.X, (int)position.Y, 10, color);
        Raylib.DrawText(Name, (int)(position.X + 20), (int)(position.Y - 30), 23, Color.Black);
    }
}
