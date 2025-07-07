using DijkstraAlgorithm.Graphs;
using DijkstraAlgorithm.Graphs.Points;

namespace DijkstraAlgorithm.Commands.DerivedCommands;

public class CommandConnectNearest : ICommand
{
    public void Execute(State State)
    {

    }

    public void Undo(State State)
    {
        throw new NotImplementedException();
    }
}
