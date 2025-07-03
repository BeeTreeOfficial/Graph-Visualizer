

namespace DijkstraAlgorithm.CommandsRelated.DerivedCommands;

public class CommandCreateConnection : ICommand
{
    private string from;
    private string to;
    public CommandCreateConnection(string from, string to)
    {
        this.from = from;
        this.to = to;
    }
    public void Execute()
    {
        Program.Graph.CreateConnection(from,to);
    }

    public void Undo()
    {
        Program.Graph.RemoveEdgeByName(from, to);
    }
}
