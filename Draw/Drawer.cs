using System.Numerics;

using Raylib_cs;

namespace DijkstraAlgorithm.Draw;

public static class Drawer
{
    public static void DrawCircle(Vector2 Position, int Radius, Color Color)
    {
        Raylib.DrawCircle((int)Position.X, (int)Position.Y, Radius, Color);
    }
    public static void DrawCircleLines(Vector2 Position, int RadiusColor, Color Color)
    {
        Raylib.DrawCircleLines((int)Position.X, (int)Position.Y, RadiusColor, Color);
    }
    public static void DrawNumber(double Value, Vector2 Position, int FontSize = 30)
    {
        Raylib.DrawText(Convert.ToString(Value), (int)Position.X, (int)Position.Y, FontSize, Color.Black);
    }
    public static void DrawNumber(double Value, Vector2 Position, Color Color, double FontSize = 30)
    {
        Raylib.DrawText(Convert.ToString((int)Value), (int)Position.X, (int)Position.Y, (int) FontSize, Color);
    }
    public static void DrawLineBetweenToPoints(Vector2 First, Vector2 Second, float Thickness, Color Color)
    {
        Raylib.DrawLineEx(First, Second, Thickness, Color);
    }
    public static void DrawTextWithOffset(string content, Vector2 Position, int Radius, int FontSize, Color Color)
    {
        Raylib.DrawText(content, (int)Position.X + Radius, (int)Position.Y - Radius, FontSize, Color);
    }
}
