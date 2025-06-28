using Raylib_cs;
using System.Numerics;

namespace DijkstraAlgorithm;




public class Point
{
    Vector2 Position;
    public void Draw()
    {
        Raylib.DrawCircle((int)Position.X, (int)Position.Y, 10, Color.Red);
    }

    public Dictionary<string, Edge> Edges;
    public string Name = "UNNAMED";
    public Point(string Name, Dictionary<string, Edge> Neighbors)
    {
        this.Name = Name;
        Position = new(Program.random.Next( 100), Program.random.Next(100));
        this.Edges = Neighbors;
    }

    public Point(string Name)
    {
        this.Name = Name;
        Position = new(Program.random.Next(1000), Program.random.Next(1000));
        this.Edges = [];
    }
    public void AddNeighbor(double distance, Point point, bool OneWay = false)
    {
        Edge NewEdge = new(distance, point);
        if (Edges.ContainsKey(NewEdge.EndPoint.Name))
        {
            return;
        }
        Edges.Add(NewEdge.EndPoint.Name, NewEdge);
        if (OneWay)
        {
            return;
        }
        NewEdge.EndPoint.AddNeighbor(NewEdge.Distance, this);
    }

}

public class Edge(double Distance, Point EndPoint)
{
    public double Distance = Distance;
    public Point EndPoint = EndPoint;
}
