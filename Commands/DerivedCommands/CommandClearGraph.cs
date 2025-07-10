using DijkstraAlgorithm.Graphs;
using DijkstraAlgorithm.Graphs.Points;
using DijkstraAlgorithm.Graphs.Edges;

namespace DijkstraAlgorithm.Commands.DerivedCommands;

public class CommandClearGraph : ICommand
{
    Dictionary<string, Point> PreviousPoints = [];
    Dictionary<(string, string), Edge> PreviousEdges = [];

    public void Execute(State State)
    {
        PreviousPoints = State.Graph.Points;
        PreviousEdges = State.Graph.Edges;
        State.Graph.Clear();
    }

    public void Undo(State State)
    {
        
    }
}
