using DijkstraAlgorithm.Graphs.Points;
namespace DijkstraAlgorithm.Persistence;

public partial class Storage
{
    public static void Save(string NameOfFileToSafeTo, State State)
    {
        List<string> Content = []; 
        foreach (var (Name, Point) in State.Graph.Points)
        {
            Content.Add($"Point: {Name} {Point.Position.X} {Point.Position.Y} {Point.Color} {Point.Radius}");       
        }
        foreach (var Edges in State.Graph.Edges)
        {
            Content.Add($"Edge: {Edges.Key.Item1} {Edges.Key.Item2}");
        }
        Content.Add($"Camera: {State.Camera.MaxSpeed} {State.Camera.Position.X} {State.Camera.Position.Y}");
        string ContentString = string.Empty;
        foreach (var Line in Content)
        {
            ContentString += Line + "\n";
        }
        File.WriteAllText(NameOfFileToSafeTo , ContentString);
    }
}
