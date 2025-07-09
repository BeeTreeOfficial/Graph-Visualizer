namespace DijkstraAlgorithm.Interfaces;

public interface IPoint: IPosition
{
    public void Update();
    public void Draw();
    public void DrawHighlight();
}
