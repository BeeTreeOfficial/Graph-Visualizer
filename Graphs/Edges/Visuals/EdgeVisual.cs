using DijkstraAlgorithm.Draw;
using Raylib_cs;
using System.Numerics;

namespace DijkstraAlgorithm.Graphs.Edges;

public partial class Edge
{
    public float Thickness { get { return Math.Clamp((1 / Length) * 1000, 5, 15); } }
    public void Draw()
    {
        float Length = (this.Length);
        float Thickness = this.Thickness;
        Color CalculatedAverage = Raylib.ColorLerp(Left.Color, Right.Color, 0.5f);
        Color Color = Raylib.ColorContrast(CalculatedAverage, Math.Clamp(Length / 500f - 0.5f, -1, 1));
        Vector2 Position = new(Left.Position.X + Right.Position.X, Left.Position.Y + Right.Position.Y);
        Position /= 2;
        Drawer.DrawLineBetweenToPoints(Left.Position, Right.Position, Thickness + Thickness * 0.8f, Color.Black);
        Drawer.DrawLineBetweenToPoints(Left.Position, Right.Position, Thickness, Color);
        Drawer.DrawNumber(Length, Position, Raylib.ColorBrightness(Color, 0.9f), Math.Sqrt(Length) * 2);
    }
}
