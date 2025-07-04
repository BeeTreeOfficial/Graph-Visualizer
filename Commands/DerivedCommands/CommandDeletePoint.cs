using DijkstraAlgorithm.Graphs.Points;

namespace DijkstraAlgorithm.Commands.DerivedCommands;

public class CommandDeletePoint : ICommand
{
    string NameOfPointToRemove;
    public CommandDeletePoint(string Name) { NameOfPointToRemove = Name; }
    public void Execute()
    {
        if (Program.SelectedPoint != null && Program.SelectedPoint.Name == NameOfPointToRemove) Program.SelectedPoint = null;
        Program.Graph.RemovePoint(NameOfPointToRemove);
    }
    public void Undo()
    {
    }
}
