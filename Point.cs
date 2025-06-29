using Raylib_cs;

using System.Numerics;

namespace DijkstraAlgorithm;


public class Point
{
    public static readonly Dictionary<string, Color> ColorsConst = new()
    {
        ["RED"] = Color.Red,
        ["GREEN"] = Color.Green,
        ["BLACK"] = Color.Black,
        ["BLUE"] = Color.Blue,
        ["YELLOW"] = Color.Yellow,
    };

    public Vector2 Position = Vector2.Zero;
    public Color color = Color.Red;

    public void Shuffle()
    {
        Position = new(Program.random.Next(1000), Program.random.Next(1000));
    }

    public void Draw()
    {
        Raylib.DrawCircle((int)Position.X, (int)Position.Y, 6, color);
        Raylib.DrawText(Name, (int)(Position.X + 20), (int)(Position.Y - 30), 23, Color.Black);
    }

    public Dictionary<string, Edge> ConnectedEdges = [];
    public string Name;

    public Point(string Name)
    {
        this.Name = Name;
    }
    public Point(string Name, Vector2 Position)
    {
        this.Name = Name;
        this.Position = Position;
    }

    public Point(string name, Vector2 position, string ColorToUse)
    {
        Position = position;
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
