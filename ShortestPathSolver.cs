namespace DijkstraAlgorithm;

public class ShortestPathSolver(Graph graph, string Name)
{
    private HashSet<string> Visited = [];
    private Dictionary<string, double> Sheet = [];
    private readonly Dictionary<string, Point> points = graph.points;
    private readonly string StartPointName = Name;
    public Dictionary<string, double> Solve()
    {
        InitializeSheet();
        for (int i = 0; i < points.Count; i++)
        {
            if (Visited.Count == points.Count){break;}
            Point? CurrentPoint = GetCurrentPoint();
            if (CurrentPoint == null) { break; }
            foreach (var item in CurrentPoint.ConnectedEdges)
            {
                if (Visited.Contains(item.Key)) { continue; }
                double AlternativeDistance = Sheet[CurrentPoint.Name] + item.Value.Length;
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


