using DijkstraAlgorithm.Draw;
using Raylib_cs;
using System.Numerics;

namespace DijkstraAlgorithm.Graphs.Edges;

public partial class Edge
{
    private Vector2 ShadowOffset = Vector2.Zero;
    public Color Color { get; private set; }
    public float Thickness { get { return Math.Clamp((1 / Length) * 1000, 5, 15) + 4; } }
    private void CalculateShadowOffset()
    {
        ShadowOffset = Vector2.Subtract(new Vector2(Raylib.GetScreenWidth() / 2, Raylib.GetScreenHeight() / 2), Raylib.GetMousePosition());
        ShadowOffset /= 100;
    }
    public void DrawShadow()
    {
        CalculateShadowOffset();
        Color CalculatedAverage = Raylib.ColorLerp(Left.Color, Right.Color, 0.5f);
        Color = Raylib.ColorContrast(CalculatedAverage, Math.Clamp(Length / 500f - 0.5f, -1, 1));
        
        Drawer.DrawLineBetweenToPoints(Left.Position + ShadowOffset, Right.Position + ShadowOffset, Thickness + 5, Raylib.ColorBrightness(Raylib.ColorAlpha(Color, 0.5f), -1f));
    }
    public void Draw()
    {
        float Length = (this.Length);
        float Thickness = this.Thickness;
        Vector2 Position = new Vector2(Left.Position.X + Right.Position.X, Left.Position.Y + Right.Position.Y) / 2f;
        Drawer.DrawLineBetweenToPoints(Left.Position, Right.Position, Thickness + 3, Raylib.ColorBrightness(Color, -0.6f));
        Drawer.DrawLineBetweenToPoints(Left.Position, Right.Position, Thickness, Raylib.ColorBrightness(Color, -0.3f));
        Drawer.DrawLineBetweenToPoints(Left.Position, Right.Position, Thickness - 3, Color);
        Drawer.DrawLineBetweenToPoints(Left.Position, Right.Position, Thickness - 5, Raylib.ColorBrightness(Color, 0.05f));
        Drawer.DrawNumber(Length, Position + ShadowOffset, Raylib.ColorAlpha(Color.Black, 0.5f), Math.Sqrt(Length) * 2.3);
        Drawer.DrawNumber(Length, Position, Raylib.ColorBrightness(Color, 0.9f), Math.Sqrt(Length) * 2);
    }
}
