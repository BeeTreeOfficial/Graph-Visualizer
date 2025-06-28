using Raylib_cs;
using System.Numerics;

namespace DijkstraAlgorithm;




public class Point
{
    public Vector2 Position;

    public void Shuffle()
    {
        Position = new(Program.random.Next(1000), Program.random.Next(1000));
        RecalculateDistances();
    }
    public void DrawLines()
    {
        
        foreach (var item in Edges)
        {
            Raylib.DrawLine((int)Position.X, (int)Position.Y, (int)item.Value.EndPoint.Position.X, (int)item.Value.EndPoint.Position.Y, Color.Red);
        }
    }
    public void DrawPoints()
    {
        Raylib.DrawCircle((int)Position.X, (int)Position.Y, 10, Color.White);
        Raylib.DrawCircleLines((int)Position.X, (int)Position.Y, 10, Color.Red);
        Raylib.DrawText(Name, (int)(Position.X - 4), (int)(Position.Y - 4.5), 13, Color.Black);
    }

    public Dictionary<string, Edge> Edges;
    public string Name = "UNNAMED";

    public Point(string Name)
    {
        this.Name = Name;
        Position = new(Program.random.Next(1000), Program.random.Next(1000));
        this.Edges = [];
    }
    private void RecalculateDistances()
    {
        foreach (var item in Edges)
        {
            item.Value.Distance = CalculateDistance(item.Value.EndPoint);
        }
    }
    private float CalculateDistance(Point point)
    {
        return Math.Abs(Vector2.Distance(Position, point.Position));
    }
    public void AddNeighbor(Point point, bool OneWay = false)
    {
        Edge NewEdge = new(CalculateDistance(point), point);
        if (Edges.ContainsKey(NewEdge.EndPoint.Name))
        {
            return;
        }
        Edges.Add(NewEdge.EndPoint.Name, NewEdge);
        if (OneWay)
        {
            return;
        }
        NewEdge.EndPoint.AddNeighbor(this);
    }

}

public class Edge(double Distance, Point EndPoint)
{
    public double Distance = Distance;
    public Point EndPoint = EndPoint;
}
