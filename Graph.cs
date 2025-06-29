
using System.Numerics;

namespace DijkstraAlgorithm;
public class Graph
{
    public Dictionary<string, Point> points = [];
    public Dictionary<(string, string), Edge> edges = [];


    public void Print()
    {
        Console.WriteLine(WritingConstants.HugeDash);
        foreach (var item in points)
        {
            Console.WriteLine(WritingConstants.UnderDash);
            Console.Write($"The Point is Named: {item.Key} || Contains Links To: \n");
            foreach (var point in item.Value.ConnectedEdges)
            {
                Console.Write($"\n" +
                    $"    " +
                    $"{point.Key} - with distance: {(int)point.Value.Length}; ");
            }
            Console.WriteLine();
        }
        Console.WriteLine(WritingConstants.UnderDash);
        Console.WriteLine(WritingConstants.HugeDash);
    }

    public void CreateConnection(string from, string to, bool OneWay = false)
    {
        if (!points.ContainsKey(from) || !points.ContainsKey(to) || DoesThisKindOfConnectionExist(from, to) || from == to)
        {
            return;
        }
        Edge edge = new(points[from], points[to]);

        edges.Add((from, to), edge);
        points[from].LinkToEdge(edge);
        if (OneWay) return;
        points[to].LinkToEdge(edge);
    }


    public void AddToPoints(Point point)
    {
        if (points.ContainsKey(point.Name))
        {
            Console.WriteLine("Attempted to add already existing point, " +
                "or another point with the same name");
            return;
        }
        points.Add(point.Name, point);
    }


    public void RemovePoint(string PointName)
    {
        if (!points.ContainsKey(PointName)) { return; }
        Point PointToDelete = points[PointName];
        foreach (var item in PointToDelete.ConnectedEdges)
        {
            RemoveEdge(item.Value);
        }
        points.Remove(PointName);
    }

    public void RemoveEdge(Edge EdgeToRemove)
    {
        EdgeToRemove.DetachFromBothPoints();
        if (edges.ContainsKey((EdgeToRemove.Left.Name, EdgeToRemove.Right.Name)))
        {
            edges.Remove((EdgeToRemove.Left.Name, EdgeToRemove.Right.Name));
        }
        else if (edges.ContainsKey((EdgeToRemove.Right.Name, EdgeToRemove.Left.Name)))
        {
            edges.Remove((EdgeToRemove.Right.Name, EdgeToRemove.Left.Name));
        }
    }
    public void Draw()
    {
        foreach (var item in edges)
        {
            item.Value.Draw();
        }
        foreach (var item in points)
        {
            item.Value.Draw();
        }
    }
    private bool DoesThisKindOfConnectionExist(string first, string second)
    {
        if (edges.ContainsKey((first, second)) || edges.ContainsKey((second, first)))
        {
            Console.WriteLine("This Connection Already Exists");
            return true;
        }
        return false;
    }

    public void CreateRandomConnections()
    {
        edges.Clear();
        int AmountOfConnections = Program.random.Next(1, points.Count) * 3;
        List<string> Names = [.. points.Keys];
        for (int i = 0; i < AmountOfConnections; i++)
        {
            (int, int) Numbers = (Program.random.Next(points.Count), Program.random.Next(points.Count));
            CreateConnection(Names[Numbers.Item1], Names[Numbers.Item2]);
        }
    }

    public void Shuffle()
    {
        foreach (var item in points)
        {
            item.Value.Shuffle();
        }
    }
}


