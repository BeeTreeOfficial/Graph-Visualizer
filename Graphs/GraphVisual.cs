namespace DijkstraAlgorithm.Graphs;

public partial class Graph
{
    public void Draw()
    {
        foreach (var item in edges)
        {
            item.Value.Draw();
        }
        foreach (var item in points)
        {
            item.Value.Draw();
        }
    }
}
