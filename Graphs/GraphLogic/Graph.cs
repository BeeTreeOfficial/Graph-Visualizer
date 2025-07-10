using Raylib_cs;
using DijkstraAlgorithm.Graphs.Edges;
using DijkstraAlgorithm.Graphs.Points;

namespace DijkstraAlgorithm.Graphs;
public partial class Graph
{
    public Dictionary<(string, string), Edge> Edges { get; private set;}
    public Dictionary<string, Point> Points { get; private set; }
    public Point? GetPoint(string PointName)
    {
        Points.TryGetValue(PointName, out Point? point);
        return point;
    }
    public Graph()
    {
        Points = [];
        Edges = [];
    }
    public void CreateConnection(string from, string to, bool OneWay = false)
    {
        if (!Points.TryGetValue(from, out Point? PointFrom) || !Points.TryGetValue(to, out Point? PointTo) || DoesThisKindOfConnectionExist(from, to) || from == to) return;
        Edge edge = new(PointFrom, PointTo);
        Edges.Add((from, to), edge);
        PointFrom.LinkToEdge(edge);
        if (OneWay) return;
        PointTo.LinkToEdge(edge);
    }
    public void AddToPoints(Point point)
    {
        if (Points.ContainsKey(point.Name))
        {
            Console.WriteLine("Attempted to add already existing point, " +
                "or another point with the same name");
            return;
        }
        Points.Add(point.Name, point);
    }
    public void RemovePoint(string PointName)
    {
        if (!Points.TryGetValue(PointName, out Point? PointToDelete)) return;
        foreach (var item in PointToDelete.ConnectedEdges)
        {
            RemoveEdge(item.Value);
        }
        Points.Remove(PointName);
    }
    private void RemoveEdge(Edge EdgeToRemove)
    {
        EdgeToRemove.DetachFromBothPoints();
        if (Edges.ContainsKey((EdgeToRemove.Left.Name, EdgeToRemove.Right.Name)))
        {
            Edges.Remove((EdgeToRemove.Left.Name, EdgeToRemove.Right.Name));
        }
        else if (Edges.ContainsKey((EdgeToRemove.Right.Name, EdgeToRemove.Left.Name)))
        {
            Edges.Remove((EdgeToRemove.Right.Name, EdgeToRemove.Left.Name));
        }
    }
    public void RemoveEdgeByName(string first, string second)
    {
        if (Edges.ContainsKey((first, second)))
        {
            RemoveEdge(Edges[(first, second)]);
        }
        else if (Edges.ContainsKey((second, first)))
        {
            RemoveEdge(Edges[(second, first)]);
        }
    }
    private bool DoesThisKindOfConnectionExist(string first, string second)
    {
        if (Edges.ContainsKey((first, second)) || Edges.ContainsKey((second, first)))
        {
            Console.WriteLine("This Connection Already Exists");
            return true;
        }
        return false;
    }

    public void Shuffle()
    {
        foreach (var item in Points)
        {
            item.Value.Shuffle();
        }
    }
    public void Clear()
    {
        Points = [];
        Edges = [];
    }
}

