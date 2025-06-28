namespace DijkstraAlgorithm;

public class Graph
{
    public Dictionary<string, Point> points = [];
    

    public void Print()
    {
        Console.WriteLine("------------------------------------------------------------------------------------------------");
        foreach (var item in points)
        {
            Console.WriteLine("___________________________________________________ \n");
            Console.Write($"The Point is Named: {item.Key} || Contains Links To: \n");
            foreach (var point in item.Value.Edges)
            {
                Console.Write($"\n    {point.Key} - with distance: {point.Value.Distance}; ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("___________________________________________________ \n");
        Console.WriteLine("------------------------------------------------------------------------------------------------");
    }

    public void AddToPoints(Point point)
    {
        points.Add(point.Name, point);
    }

    public void Draw()
    {
        foreach (var item in points)
        {
            item.Value.Draw();
        }
    }

    public void AddConnection(string from, double Distance, string to)
    {
        points[from].AddNeighbor(Distance, points[to]);
    }

    public void AddOneWayConnection(string from, double Distance, string to)
    {
        points[from].AddNeighbor(Distance, points[to], true);
    }

    public Dictionary<string, double> SolveDijkstra(string Name)
    {
        ShortestPathSolver Solver = new(points, Name);
        return Solver.Solve();
    }
}

public class ShortestPathSolver(Dictionary<string, Point> Points, string Name)
{
    private HashSet<string> Visited = [];
    private Dictionary<string, double> Sheet = [];
    private readonly Dictionary<string, Point> points = Points;
    private readonly string StartPointName = Name;
    public Dictionary<string, double> Solve()
    {
        InitializeSheet();
        for (int i = 0; i < points.Count; i++)
        {
            if (Visited.Count == points.Count){break;}
            Point? CurrentPoint = GetCurrentPoint();
            if (CurrentPoint == null) { break; }
            foreach (var item in CurrentPoint.Edges)
            {
                if (Visited.Contains(item.Key)) { continue; }
                double AlternativeDistance = Sheet[CurrentPoint.Name] + item.Value.Distance;
                if (Sheet[item.Key] > AlternativeDistance)
                {
                    Sheet[item.Key] = AlternativeDistance;
                }
            }
            Visited.Add(CurrentPoint.Name);
        }

        return Sheet;
    }

    private Point? GetCurrentPoint()
    {
        double MinDistance = double.PositiveInfinity;
        Point? CurrentPoint = null;
        foreach (var point in Sheet)
        {
            if (point.Value < MinDistance && !Visited.Contains(point.Key))
            {
                MinDistance = point.Value;
                CurrentPoint = points[point.Key];
            }
        }
        return CurrentPoint;
    }

    private void InitializeSheet()
    {
        foreach (var item in points)
        {
            Sheet.Add(item.Key, double.PositiveInfinity);
        }
        Sheet[StartPointName] = 0;
    }

}


