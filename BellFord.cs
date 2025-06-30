using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraAlgorithm
{
    public class BellFord
    {
        private Graph graph;
        private Dictionary<string, ResultData> Sheet = [];
        public BellFord(Graph graph, string Name)
        {
            this.graph = graph;
            for (int i = 0; i < this.graph.points.Count; i++)
            {
                Sheet.Add(this.graph.Points.ElementAt(i).Value.Name, new(double.PositiveInfinity, null));
            }
            Sheet[Name].Price = 0;
        }

        public Dictionary<string, ResultData> Solve()
        {
            for (int i = 0; i < Sheet.Count - 1; i++)
            {
                foreach (var point in graph.points.Values)
                {
                    foreach (var edge in point.ConnectedEdges)
                    {
                        double NewDistance = Sheet[point.Name].Price + edge.Value.Length;
                        if (NewDistance < Sheet[edge.Key].Price)
                        {
                            Sheet[edge.Key].Price = NewDistance;
                            Sheet[edge.Key].PreviousPoint = point.Name;
                        }
                    }
                }
            }
            return Sheet;
        }
    }
}
