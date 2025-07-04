using DijkstraAlgorithm.Graphs;
using DijkstraAlgorithm.Mathematics;
using DijkstraAlgorithm.Structs;

namespace DijkstraAlgorithm.Commands.DerivedCommands;

public class CommandSolveDextra : ICommand
{
    Result Result;
    public CommandSolveDextra(Graph graph, string Begin)
    {
        Result = Dijkstra.Solve(graph, Begin);
    }
    public void Execute()
    {
        
    }
    public void Undo()
    {
        throw new NotImplementedException();
    }
}
