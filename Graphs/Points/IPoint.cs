

namespace DijkstraAlgorithm.Graphs.Points;

public interface IPoint: IPosition
{
    public void Update();
    public void Draw();
    public void DrawHighlight();
}
