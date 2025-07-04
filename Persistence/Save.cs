using DijkstraAlgorithm.Graphs;
using DijkstraAlgorithm.Graphs.Points;
using DijkstraAlgorithm.Graphs.Edges;
using Raylib_cs;

namespace DijkstraAlgorithm.Persistence;

public class Save
{
    public static void SaveGraphTo(Graph graph, string NameOfFileToSafeTo)
    {
        List<string> Content = []; 
        foreach (var (Name, Point) in graph.Points)
        {
            Content.Add($"Point: {Name} {Point.position.X} {Point.position.Y} {Point.Color}");       
        }
        foreach (var Edges in graph.edges)
        {
            Content.Add($"Edge: {Edges.Key.Item1} {Edges.Key.Item2}");
        }
        string ContentString = string.Empty;
        foreach (var Line in Content)
        {
            ContentString += Line + "\n";
        }
        File.WriteAllText(NameOfFileToSafeTo , ContentString);
    }
}
