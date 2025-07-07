using Raylib_cs;
using System.Numerics;

namespace DijkstraAlgorithm.Cameras;

public interface ICamera
{
    public float MaxSpeed { get; set; }
    public Camera2D Body { get; }
    public Vector2 Position { get; set; }
    public void Update();
}
