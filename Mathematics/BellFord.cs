using DijkstraAlgorithm.Graphs;
using DijkstraAlgorithm.ResultClasses;

namespace DijkstraAlgorithm.Mathematics
{
    public class BellFord
    {
        private Graph graph;
        private Result Sheet = new();
        public BellFord(Graph graph, string Name)
        {
            this.graph = graph;
            for (int i = 0; i < this.graph.points.Count; i++)
            {
                Sheet.Body.Add(this.graph.Points.ElementAt(i).Value.Name, new(double.PositiveInfinity, null));
            }
            Sheet.Body[Name].Price = 0;
        }

        public Result Solve()
        {
            for (int i = 0; i < Sheet.Body.Count - 1; i++)
            {
                foreach (var point in graph.points.Values)
                {
                    foreach (var edge in point.ConnectedEdges)
                    {
                        double NewDistance = Sheet.Body[point.Name].Price + edge.Value.Length;
                        if (NewDistance < Sheet.Body[edge.Key].Price)
                        {
                            Sheet.Body[edge.Key].Price = NewDistance;
                            Sheet.Body[edge.Key].PreviousPoint = point.Name;
                        }
                    }
                }
            }
            return Sheet;
        }
    }
}
