

namespace DijkstraAlgorithm.CommandsRelated;

public class CommandDeque
{
    private LinkedList<ICommand> commands = new();
    public LinkedList<ICommand> Commands { get { return commands; } }

    public  void Execute(ICommand command)
    {
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
