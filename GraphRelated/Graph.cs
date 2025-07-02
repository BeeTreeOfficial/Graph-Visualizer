using DijkstraAlgorithm.GraphRelated.Edges;
using DijkstraAlgorithm.GraphRelated.Points;
namespace DijkstraAlgorithm.GraphRelated;
public class Graph
{
    public Dictionary<string, Point> points = [];
    public Dictionary<(string, string), Edge> edges = [];

    public Dictionary<string, Point> Points {  get { return points; } }
    public Point? GetPoint(string PointName)
    {
        points.TryGetValue(PointName, out Point? point);
        return point;
    }
    public Graph() { }
    public Graph(Dictionary<string, Point> points, Dictionary<(string, string), Edge> edges)
    {
        this.points = points;
        this.edges = edges;
    }

    public void Print()
    {
        Console.WriteLine("---------------------");
        foreach (var item in points)
        {
            Console.Write($"The Point is Named: {item.Key} || Contains Links To: \n");
            foreach (var point in item.Value.ConnectedEdges)
            {
                Console.Write($"\n" +
                    $"    " +
                    $"{point.Key} - with distance: {(int)point.Value.Length}; ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("---------------------");
    }

    public void CreateConnection(string from, string to, bool OneWay = false)
    {
        if (!points.TryGetValue(from, out Point? PointFrom) || !points.TryGetValue(to, out Point? PointTo) || DoesThisKindOfConnectionExist(from, to) || from == to) return;
        Edge edge = new(PointFrom, PointTo);
        edges.Add((from, to), edge);
        PointFrom.LinkToEdge(edge);
        if (OneWay) return;
        PointTo.LinkToEdge(edge);
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
        if (!points.TryGetValue(PointName, out Point? PointToDelete)) return;
        foreach (var item in PointToDelete.ConnectedEdges)
        {
            RemoveEdge(item.Value);
        }
        points.Remove(PointName);
    }

    private void RemoveEdge(Edge EdgeToRemove)
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

    public void RemoveEdgeByName(string first, string second)
    {
        if (edges.ContainsKey((first, second)))
        {
            RemoveEdge(edges[(first, second)]);
        }
        else if (edges.ContainsKey((second, first)))
        {
            RemoveEdge(edges[(second, first)]);
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

