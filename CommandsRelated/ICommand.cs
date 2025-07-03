namespace DijkstraAlgorithm.CommandsRelated;
public interface ICommand
{
    public void Execute();
    public void Undo();
}
