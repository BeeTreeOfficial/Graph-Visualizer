using Raylib_cs;
using System.Numerics;

namespace DijkstraAlgorithm.Cameras;

public abstract class BaseCamera
{
    protected Camera2D CameraBody;

    public BaseCamera(Vector2 Offset, Vector2 Target, float Zoom)
    {
        CameraBody = new Camera2D
        {
            Offset = Offset,
            Target = Target,
            Rotation = 0,
            Zoom = Zoom
        };
    }

    public abstract void Update();


    public Camera2D GetBody()
    {
        return CameraBody;
    }
}
