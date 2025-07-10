namespace DijkstraAlgorithm.Graphs;

public partial class Graph
{
    public void Draw()
    {
        foreach (var (_, edge) in Edges)
        {
            edge.DrawShadow();
        }
        foreach (var (_, edge) in Edges)
        {
            edge.Draw();
        }
        foreach (var (_, point) in Points)
        {
            point.Draw();
        }
    }
}
