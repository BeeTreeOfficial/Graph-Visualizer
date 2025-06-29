namespace DijkstraAlgorithm;

struct ResultData
{
    double Price;
    string PreviousOne;
}
public class DextraSolve(Graph graph)
{
    private HashSet<string> Visited = [];
    private Dictionary<string, double> Sheet = [];
    private readonly Dictionary<string, Point> points = graph.points;
    public Dictionary<string, double> Solve(string StartPointName)
    {
        if (!points.ContainsKey(StartPointName))
        {
            throw new IndexOutOfRangeException($"{StartPointName} Does not exist in this graph");
        }
        InitializeSheet(StartPointName);
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

    private void InitializeSheet(string StartPointName)
    {
        foreach (var item in points)
        {
            Sheet.Add(item.Key, double.PositiveInfinity);
        }
        Sheet[StartPointName] = 0;
    }

}


