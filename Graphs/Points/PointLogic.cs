using Raylib_cs;
using DijkstraAlgorithm.Graphs.Edges;
using System.Numerics;

namespace DijkstraAlgorithm.Graphs.Points;
public partial class Point: IPosition
{
    public string Name;
    private Vector2 Velocity = Vector2.Zero;

    public Dictionary<string, Edge> ConnectedEdges = [];
    public Vector2 Position { get; private set; }
    public Point(string name, Vector2? Position = null, Color? ColorToUse = null)
    {
        if (ColorToUse != null) color = ColorToUse.Value;
        if (Position != null) this.Position = Position.Value;
        Name = name;
    }
    public void Shuffle()
    {
        Position = new(Program.random.Next(1000), Program.random.Next(1000));
    }
    public void Update()
    {
        Vector2 Direction = Vector2.Zero;
        Direction.X = Raylib.IsKeyDown(KeyboardKey.Right) - Raylib.IsKeyDown(KeyboardKey.Left);
        Direction.Y = Raylib.IsKeyDown(KeyboardKey.Down) - Raylib.IsKeyDown(KeyboardKey.Up);
        if (Raylib.IsKeyDown(KeyboardKey.LeftShift)) Direction /= 4;
        Velocity = Direction * 800;
        Move();
    }
    public void Move()
    {
        Position += Velocity * Raylib.GetFrameTime();
    }
    public void LinkToEdge(Edge edge)
    {
        if (ConnectedEdges.ContainsKey(edge.GetPointOppositeTo(this).Name)) { Console.WriteLine("ERROR, TRIED TO ADD EXISTING KEY"); return; }
        ConnectedEdges.Add(edge.GetPointOppositeTo(this).Name, edge);
    }
}
