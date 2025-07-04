

namespace DijkstraAlgorithm.Commands;

public class CommandDeque
{
    private LinkedList<ICommand> commands = new();
    public LinkedList<ICommand> Commands { get { return commands; } }

    public  void Execute(ICommand command)
    {
        if (commands.Count > 10000) commands.RemoveFirst();
        commands.AddLast(command);
        command.Execute();
    }
    public void Undo()
    {
        if (commands.Count <= 0) return;
        commands.Last().Undo();
        commands.RemoveLast();
    }
}
