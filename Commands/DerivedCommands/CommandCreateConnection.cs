namespace DijkstraAlgorithm.Commands.DerivedCommands;

public class CommandCreateConnection(string from, string to) : ICommand
{
    private readonly string from = from;
    private readonly string to = to;

    public void Execute(State State)
    {
        State.Graph.CreateConnection(from,to);
    }

    public void Undo(State State)
    {
        State.Graph.RemoveEdgeByName(from, to);
    }
}
