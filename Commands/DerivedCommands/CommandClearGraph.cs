using DijkstraAlgorithm.Graphs;
using DijkstraAlgorithm.Graphs.Points;
using DijkstraAlgorithm.Graphs.Edges;

namespace DijkstraAlgorithm.Commands.DerivedCommands;

public class CommandClearGraph : ICommand
{
    Dictionary<string, Point> PreviousPoints;
    Dictionary<(string, string), Edge> PreviousEdges;
    public CommandClearGraph()
    {
        PreviousPoints = Program.Graph.points;
        PreviousEdges = Program.Graph.edges;
    }
    public void Execute()
    {
        Program.Graph.Clear();
    }

    public void Undo()
    {
        Program.Graph.points = PreviousPoints;
        Program.Graph.edges = PreviousEdges;
    }
}
