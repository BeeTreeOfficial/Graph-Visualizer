using DijkstraAlgorithm.Graphs;
using DijkstraAlgorithm.Mathematics;
using DijkstraAlgorithm.ResultClasses;

namespace DijkstraAlgorithm.Commands.DerivedCommands;

public class CommandSolveDextra(string Begin) : ICommand
{
    readonly string Begin = Begin;
    public void Execute(State State)
    {
        Result Result = Dijkstra.Solve(State.Graph, Begin);
        Console.WriteLine(Result);
    }
    public void Undo(State State)
    {
        throw new NotImplementedException();
    }
}
