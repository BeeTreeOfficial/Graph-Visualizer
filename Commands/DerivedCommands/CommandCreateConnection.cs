namespace DijkstraAlgorithm.Commands.DerivedCommands;

public class CommandCreateConnection : ICommand
{
    private readonly string from;
    private readonly string to;
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
