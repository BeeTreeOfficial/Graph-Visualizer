
using DijkstraAlgorithm.Draw;
using DijkstraAlgorithm.Graphs.Edges;
using Raylib_cs;

namespace DijkstraAlgorithm.Graphs.Points;

public partial class Point
{
    private Color color = Color.Red;
    public Color Color { get { return color; } }
    private int Radius = 15;
    public void DrawHighlight()
    {
        Drawer.DrawCircleLines(Position, (int)(Radius * 2f), Raylib.ColorBrightness(color, 0.5f));
    }
    public void Draw()
    {
        Color TextColor = Raylib.ColorLerp(Color.White, Color, 0.2f);
        UpdateRadius();
        Drawer.DrawCircle(Position, Radius, Color);
        Drawer.DrawTextWithOffset(Name, Position, Radius, Radius, TextColor);
    }
    private void UpdateRadius()
    {
        Radius = 1;
        if (ConnectedEdges.Count <= 0) return;
        int MinSize = 0;
        if (ConnectedEdges.Count > 0)
        {
            foreach (var (_, Edge) in ConnectedEdges)
            {
                Radius += (int)Edge.Length / 25;
                int Thickness = (int)Edge.Thickness;
                if (Thickness > MinSize)
                {
                    MinSize = Thickness;
                }
            }
        }
        Radius /= ConnectedEdges.Count;
        Radius = Math.Clamp(Radius, MinSize, 60);
    }
}
