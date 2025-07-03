using DijkstraAlgorithm.GraphRelated;
using DijkstraAlgorithm.MathRelated;
using DijkstraAlgorithm.StructsRelated;

namespace DijkstraAlgorithm.CommandsRelated.DerivedCommands;

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
