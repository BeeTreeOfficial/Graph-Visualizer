using Raylib_cs;
using System.Numerics;

namespace DijkstraAlgorithm;

public class Point(string Name)
{
    public Vector2 Position = new(Program.random.Next(1000), Program.random.Next(1000));

    public void Shuffle()
    {
        Position = new(Program.random.Next(1000), Program.random.Next(1000));
    }

    public void Draw()
    {
        Raylib.DrawCircle((int)Position.X, (int)Position.Y, 10, Color.White);
        Raylib.DrawCircleLines((int)Position.X, (int)Position.Y, 10, Color.Red);
        Raylib.DrawText(Name, (int)(Position.X - 4), (int)(Position.Y - 4.5), 13, Color.Black);
    }

    public Dictionary<string, Edge> ConnectedEdges = [];
    public string Name = Name;

    public void LinkToEdge(Edge edge)
    {
        if (ConnectedEdges.ContainsKey(edge.GetPointOppositeTo(this).Name)) { Console.WriteLine("ERROR, TRIED TO ADD EXISTING KEY"); return; }
        ConnectedEdges.Add(edge.GetPointOppositeTo(this).Name, edge);
    }

}
