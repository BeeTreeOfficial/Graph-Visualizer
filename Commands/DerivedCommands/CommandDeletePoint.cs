using DijkstraAlgorithm.Graphs.Points;

namespace DijkstraAlgorithm.Commands.DerivedCommands;

public class CommandDeletePoint(string Name) : ICommand
{
    readonly string NameOfPointToRemove = Name;

    public void Execute(State State)
    {
        State.SelectedPoint = EmptyPoint.Instance;
        State.Graph.RemovePoint(NameOfPointToRemove);
    }
    public void Undo(State State)
    {
    }
}
