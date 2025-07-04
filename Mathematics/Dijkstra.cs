using DijkstraAlgorithm.Graphs;
using DijkstraAlgorithm.Graphs.Points;
using DijkstraAlgorithm.Structs;
using System.IO;

namespace DijkstraAlgorithm.Mathematics;
public class Dijkstra(Graph graph)
{

    private HashSet<string> Visited = [];
    private Result Sheet = new();
    private readonly Dictionary<string, Point> points = graph.points;
    public static Result Solve(Graph Graph, string Name)
    {
        Dijkstra dijkstra = new(Graph);
        return dijkstra.Run(Name);
    }
    public Result Run(string StartPointName)
    {
        if (!points.ContainsKey(StartPointName)) return Sheet;
        InitializeSheet(StartPointName);
        for (int i = 0; i < points.Count; i++)
        {
            if (Visited.Count == points.Count) { break; }
            Point? CurrentPoint = GetCurrentPoint();
            if (CurrentPoint == null) { break; }
            foreach (var item in CurrentPoint.ConnectedEdges)
            {
                if (Visited.Contains(item.Key)) { continue; }
                double AlternativeDistance = Sheet.Body[CurrentPoint.Name].Price + item.Value.Length;
                if (Sheet.Body[item.Key].Price > AlternativeDistance)
                {
                    Sheet.Body[item.Key].Price = AlternativeDistance;
                    Sheet.Body[item.Key].PreviousPoint = CurrentPoint.Name;
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
        foreach (var point in Sheet.Body)
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
            Sheet.Body.Add(item.Key, new(double.PositiveInfinity, null));
        }
        Sheet.Body[StartPointName].Price = 0;
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


