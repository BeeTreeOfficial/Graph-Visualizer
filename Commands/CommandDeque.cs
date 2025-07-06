

namespace DijkstraAlgorithm.Commands;

public class CommandDeque
{
    public LinkedList<ICommand> Commands { get; }
    public CommandDeque()
    {
        Commands = [];
    }
    public  void Execute(ICommand command)
    {
        if (Commands.Count > 256) Commands.RemoveFirst();
        Commands.AddLast(command);
        command.Execute();
    }
    public void Undo()
    {
        if (Commands.Count <= 0) return;
        Commands.Last().Undo();
        Commands.RemoveLast();
    }
}
