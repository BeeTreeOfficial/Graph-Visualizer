using Raylib_cs;
using DijkstraAlgorithm.Graphs.Edges;
using System.Numerics;

namespace DijkstraAlgorithm.Graphs.Points;
public class Point
{
    public void DrawHighlight()
    {
        Raylib.DrawCircleLines((int)position.X, (int)position.Y, 15, color);
    }
    public Vector2 position = Vector2.Zero;
    public Color color = Color.Red;

    public Vector2 Position { get { return position; } }
    public Color Color { get { return color; } }

    public void Shuffle()
    {
        position = new(Program.random.Next(1000), Program.random.Next(1000));
    }

    public void Draw()
    {
        Raylib.DrawRectangle((int)position.X - 5, (int)position.Y - 5, 10, 10, color);
        Raylib.DrawText(Name, (int)(position.X + 20), (int)(position.Y - 30), 23, Color.Black);
    }

    public Dictionary<string, Edge> ConnectedEdges = [];
    public string Name;
    public void Update()
    {
        Vector2 Direction = Vector2.Zero;
        Direction.X = Raylib.IsKeyDown(KeyboardKey.Right) - Raylib.IsKeyDown(KeyboardKey.Left);
        Direction.Y = Raylib.IsKeyDown(KeyboardKey.Down) - Raylib.IsKeyDown(KeyboardKey.Up);
        position += Direction * 100 * Raylib.GetFrameTime();
    }

    public void Move(Vector2 Velocity)
    {
        position += Velocity;
    }

    public Point(string name, Vector2? position = null, Color? ColorToUse = null)
    {
        if (ColorToUse != null) color = ColorToUse.Value;
        if (position != null) this.position = position.Value;
        Name = name;
    }

    public void LinkToEdge(Edge edge)
    {
        if (ConnectedEdges.ContainsKey(edge.GetPointOppositeTo(this).Name)) { Console.WriteLine("ERROR, TRIED TO ADD EXISTING KEY"); return; }
        ConnectedEdges.Add(edge.GetPointOppositeTo(this).Name, edge);
    }

}
