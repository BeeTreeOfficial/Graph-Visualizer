using DijkstraAlgorithm.Graphs.Points;

namespace DijkstraAlgorithm.Commands.DerivedCommands;

public class CommandDeletePoint : ICommand
{
    string NameOfPointToRemove;
    public CommandDeletePoint(string Name) { NameOfPointToRemove = Name; }
    public void Execute()
    {
        Program.SelectedPoint = EmptyPoint.Instance;
        Program.Graph.RemovePoint(NameOfPointToRemove);
    }
    public void Undo()
    {
    }
}
