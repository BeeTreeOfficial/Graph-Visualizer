namespace DijkstraAlgorithm.Commands;
public interface ICommand
{
    public void Execute(State State);
    public void Undo(State State);
}
