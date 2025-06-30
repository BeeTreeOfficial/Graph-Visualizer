using System.IO;

namespace DijkstraAlgorithm;
public class DijkstraSolve(Graph graph)
{

    private HashSet<string> Visited = [];
    private Dictionary<string, ResultData> Sheet = [];
    private readonly Dictionary<string, Point> points = graph.points;
    public Dictionary<string, ResultData> Solve(string StartPointName)
    {
        if (!points.ContainsKey(StartPointName))
        {
            throw new IndexOutOfRangeException($"{StartPointName} Does not exist in this graph");
        }
        InitializeSheet(StartPointName);
        for (int i = 0; i < points.Count; i++)
        {
            if (Visited.Count == points.Count) { break; }
            Point? CurrentPoint = GetCurrentPoint();
            if (CurrentPoint == null) { break; }
            foreach (var item in CurrentPoint.ConnectedEdges)
            {
                if (Visited.Contains(item.Key)) { continue; }
                double AlternativeDistance = Sheet[CurrentPoint.Name].Price + item.Value.Length;
                if (Sheet[item.Key].Price > AlternativeDistance)
                {
                    Sheet[item.Key].Price = AlternativeDistance;
                    Sheet[item.Key].PreviousPoint = CurrentPoint.Name;
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
            if (point.Value.Price < MinDistance && !Visited.Contains(point.Key))
            {
                MinDistance = point.Value.Price;
                CurrentPoint = points[point.Key];
            }
        }
        return CurrentPoint;
    }

    private void InitializeSheet(string StartPointName)
    {
        foreach (var item in points)
        {
            Sheet.Add(item.Key, new(double.PositiveInfinity, null));
        }
        Sheet[StartPointName].Price = 0;
    }

    public static List<string> GetPathToPoint(Dictionary<string, ResultData> Sheet, string Name) { 
        List<string> strings = [];
        strings.Add(Name);
        string? CurrentPreviousPoint = Sheet[Name].PreviousPoint;
        while (CurrentPreviousPoint != null)
        {
            strings.Add(CurrentPreviousPoint);
            CurrentPreviousPoint = Sheet[CurrentPreviousPoint].PreviousPoint;
        }
        strings.Reverse();
        return strings;
    }

}


