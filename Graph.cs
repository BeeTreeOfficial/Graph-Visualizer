
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
            Console.WriteLine("___________________________________________________ \n");
            Console.Write($"The Point is Named: {item.Key} || Contains Links To: \n");
            foreach (var point in item.Value.ConnectedEdges)
            {
                Console.Write($"\n    {point.Key} - with distance: {point.Value.Length}; ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("___________________________________________________ \n");
        Console.WriteLine(WritingConstants.HugeDash);
    }

    public void CreateConnection(string from, string to, bool OneWay = false)
    {
        if (DoesThisKindOfConnectionExist(from, to) || from == to) return;
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
        if (edges.ContainsKey((first, second)) || edges.ContainsKey((first, second)))
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

    public Dictionary<string, double> SolveDijkstra(string Name)
    {
        ShortestPathSolver Solver = new(points, Name);
        return Solver.Solve();
    }

    public void Shuffle()
    {
        foreach (var item in points)
        {
            item.Value.Shuffle();
        }
    }
}


