using Raylib_cs;

using System.Numerics;

namespace DijkstraAlgorithm;


public class Point
{
    public void DrawHighlight()
    {
        Raylib.DrawCircleLines((int)position.X, (int)position.Y, 15, color);
    }
    public static readonly Dictionary<string, Color> ColorsConst = new()
    {
        ["RED"] = Color.Red,
        ["GREEN"] = Color.Green,
        ["BLACK"] = Color.Black,
        ["BLUE"] = Color.Blue,
        ["YELLOW"] = Color.Yellow,
    };

    public Vector2 position = Vector2.Zero;
    public Color color = Color.Red;

    public Vector2 Position { get { return position; } }

    public void Shuffle()
    {
        position = new(Program.random.Next(1000), Program.random.Next(1000));
    }

    public void Draw()
    {
        Raylib.DrawCircle((int)position.X, (int)position.Y, 6, color);
        Raylib.DrawText(Name, (int)(position.X + 20), (int)(position.Y - 30), 23, Color.Black);
    }

    public Dictionary<string, Edge> ConnectedEdges = [];
    public string Name;

    public Point(string Name)
    {
        this.Name = Name;
    }
    public Point(string Name, Vector2 Position)
    {
        this.color = ColorsConst.ElementAt(Program.random.Next(ColorsConst.Count)).Value;
        this.Name = Name;
        this.position = Position;
    }

    public Point(Vector2 Position, Color color, Dictionary<string, Edge> ConnectedEdges, string Name)
    {
        this.position = Position;
        this.Name = Name;
        this.color = color;
        this.ConnectedEdges = ConnectedEdges ?? new Dictionary<string, Edge>();
    }

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

    public Point(string name, Vector2 position, string ColorToUse)
    {
        this.position = position;
        if (ColorsConst.TryGetValue(ColorToUse, out Color value)) color = value;
        else color = Color.Red;
        Name = name;
    }

    public void LinkToEdge(Edge edge)
    {
        if (ConnectedEdges.ContainsKey(edge.GetPointOppositeTo(this).Name)) { Console.WriteLine("ERROR, TRIED TO ADD EXISTING KEY"); return; }
        ConnectedEdges.Add(edge.GetPointOppositeTo(this).Name, edge);
    }

}
