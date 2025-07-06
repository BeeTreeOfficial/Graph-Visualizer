using DijkstraAlgorithm.Graphs;
using DijkstraAlgorithm.Graphs.Points;
using DijkstraAlgorithm.Structs;

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
        for (int _ = 0; _ < points.Count; _++)
        {
            if (Visited.Count == points.Count) { break; }
            Point? CurrentPoint = GetCurrentPoint();
            if (CurrentPoint == null) { break; }
            foreach (var (OppositePointName, EdgeToOppositePoint) in CurrentPoint.ConnectedEdges)
            {
                var SheetCell = Sheet.Body[OppositePointName];
                if (Visited.Contains(OppositePointName)) { continue; }
                double AlternativeDistance = Sheet.Body[CurrentPoint.Name].Price + EdgeToOppositePoint.Length;
                if (Sheet.Body[OppositePointName].Price > AlternativeDistance)
                {
                    SheetCell.Price = AlternativeDistance;
                    SheetCell.PreviousPoint = CurrentPoint.Name;
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
        foreach (var Point in points)
        {
            Sheet.Body.Add(Point.Key, new(double.PositiveInfinity, null));
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


