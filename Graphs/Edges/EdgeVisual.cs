using Raylib_cs;

namespace DijkstraAlgorithm.Graphs.Edges;

public partial class Edge
{
    public void Draw()
    {
        float Length = this.Length;
        byte Ratio = (byte)Math.Clamp(Length / 10, 0, 255);
        Color Color = new(Math.Min(Ratio * 4, 255), 255 - Ratio, 255 - Ratio);
        int X = ((int)Left.position.X + (int)Right.position.X) / 2;
        int Y = ((int)Left.position.Y + (int)Right.position.Y) / 2;
        Raylib.DrawLineEx(Left.position, Right.position, Math.Clamp(10000f / Length, 4, 25), Color);
        Raylib.DrawText(Convert.ToString((int)Length), X, Y, 8, Raylib_cs.Color.Black);
    }
}
