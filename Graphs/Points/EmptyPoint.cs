using DijkstraAlgorithm.Interfaces;
using System.Numerics;

namespace DijkstraAlgorithm.Graphs.Points;

public class EmptyPoint : IPoint
{
    public readonly static EmptyPoint Instance = new();
    Vector2 IPosition.Position { get { return Vector2.Zero; } }
    void IPoint.Update() { }
    void IPoint.Draw() { }
    void IPoint.DrawHighlight() { }
}
