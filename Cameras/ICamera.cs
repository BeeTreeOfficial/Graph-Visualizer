using Raylib_cs;
using System.Numerics;

namespace DijkstraAlgorithm.Cameras;

public interface ICamera
{
    public float Speed { get; set; }
    public Camera2D Body { get; }
    public void Update();
}
