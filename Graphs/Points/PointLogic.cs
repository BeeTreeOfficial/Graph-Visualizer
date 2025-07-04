using Raylib_cs;
using DijkstraAlgorithm.Graphs.Edges;
using System.Numerics;

namespace DijkstraAlgorithm.Graphs.Points;
public partial class Point
{
    public string Name;

    public Dictionary<string, Edge> ConnectedEdges = [];

    public Vector2 position = Vector2.Zero;
    public Vector2 Position { get; }
    public Point(string name, Vector2? position = null, Color? ColorToUse = null)
    {
        if (ColorToUse != null) color = ColorToUse.Value;
        if (position != null) this.position = position.Value;
        Name = name;
    }
    public void Shuffle()
    {
        position = new(Program.random.Next(1000), Program.random.Next(1000));
    }
    public void Update()
    {
        Vector2 Direction = Vector2.Zero;
        Direction.X = Raylib.IsKeyDown(KeyboardKey.Right) - Raylib.IsKeyDown(KeyboardKey.Left);
        Direction.Y = Raylib.IsKeyDown(KeyboardKey.Down) - Raylib.IsKeyDown(KeyboardKey.Up);
        position += Direction * 1000 * Raylib.GetFrameTime();
    }
    public void Move(Vector2 Velocity)
    {
        position += Velocity;
    }
    public void LinkToEdge(Edge edge)
    {
        if (ConnectedEdges.ContainsKey(edge.GetPointOppositeTo(this).Name)) { Console.WriteLine("ERROR, TRIED TO ADD EXISTING KEY"); return; }
        ConnectedEdges.Add(edge.GetPointOppositeTo(this).Name, edge);
    }
}
