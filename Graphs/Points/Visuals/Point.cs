using System.Numerics;

using Raylib_cs;

using DijkstraAlgorithm.Draw;

namespace DijkstraAlgorithm.Graphs.Points;

public partial class Point
{
    private Color color = Color.Red;
    private Vector2 ShadowOffset = Vector2.Zero;
    private void CalculateShadowOffset()
    {
        ShadowOffset = Vector2.Subtract(new Vector2(Raylib.GetScreenWidth() / 2, Raylib.GetScreenHeight() / 2), Raylib.GetMousePosition());
        ShadowOffset /= 200;
    }
    public Color Color { get { return color; } }
    public int Radius { get; private set; }
    public void DrawHighlight()
    {
        Drawer.DrawCircleLines(Position, (int)(Radius * 2f), Raylib.ColorBrightness(color, 0.5f));
    }
    public void Draw()
    {
        CalculateShadowOffset();
        Color TextColor = Raylib.ColorLerp(Color.White, Color, 0.2f);
        Drawer.DrawCircle(Position + ShadowOffset, Radius + 4, Raylib.ColorBrightness(Raylib.ColorAlpha(color, 0.5f), -0.9f));
        Drawer.DrawCircle(Position, Radius + 3, Raylib.ColorBrightness(color, -0.6f));
        Drawer.DrawCircle(Position, Radius + 2, Raylib.ColorBrightness(color, -0.3f));
        Drawer.DrawCircle(Position, Radius, Color);
        Drawer.DrawCircle(Position, Radius - 3, Raylib.ColorBrightness(color, 0.3f));
        Drawer.DrawCircle(Position, Radius - 6, Raylib.ColorBrightness(color, 0.6f));
        Drawer.DrawTextWithOffset(Name, Position, Radius, Radius, TextColor);
    }
}
