using DijkstraAlgorithm.Graphs.Interfaces;
using System.Numerics;

namespace DijkstraAlgorithm.Graphs.Points;

public class EmptyPoint : IPoint
{
    public static EmptyPoint Instance = new EmptyPoint();

    Vector2 IPosition.Position { get { return Vector2.Zero; } }

    void IPoint.Update()
    {

    }

    void IPoint.Draw()
    {

    }

    void IPoint.DrawHighlight()
    {

    }
}
