

namespace DijkstraAlgorithm.Commands;

public class CommandDeque
{
    public LinkedList<ICommand> Commands { get; }
    public CommandDeque()
    {
        Commands = [];
    }
    public  void Execute(ICommand command, State State)
    {
        if (Commands.Count > 256) Commands.RemoveFirst();
        Commands.AddLast(command);
        command.Execute(State);
    }
    public void Undo(State State)
    {
        if (Commands.Count <= 0) return;
        Commands.Last().Undo(State);
        Commands.RemoveLast();
    }
}
