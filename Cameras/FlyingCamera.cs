using Raylib_cs;
using System.Numerics;

namespace DijkstraAlgorithm.Cameras;

public class FlyingCamera(Vector2 Target, float Zoom, int MaxSpeed) : BaseCamera(new(Raylib.GetScreenWidth() / 2, Raylib.GetScreenHeight() / 2), Target, Zoom)
{
    private readonly int MaxSpeed = MaxSpeed * 1000;
    Vector2 Velocity = new(0, 0);

    public void Increase(float zoom)
    {
        CameraBody.Zoom += zoom;
    }
    static Vector2 GetMovementInput()
    {
        return new Vector2(Raylib.IsKeyDown(KeyboardKey.D) - Raylib.IsKeyDown(KeyboardKey.A),
            Raylib.IsKeyDown(KeyboardKey.S) - Raylib.IsKeyDown(KeyboardKey.W));
    }


    private void CalculateVelocity()
    {
        Vector2 Direction = GetMovementInput();
        Velocity = Direction * (MaxSpeed / CameraBody.Zoom) * Raylib.GetFrameTime();
    }
    public override void Update()
    {
        if (Raylib.IsKeyDown(KeyboardKey.E) - Raylib.IsKeyDown(KeyboardKey.Q))
        {
            CameraBody.Zoom = Math.Clamp(CameraBody.Zoom + (Raylib.IsKeyDown(KeyboardKey.E) - Raylib.IsKeyDown(KeyboardKey.Q))
                * Raylib.GetFrameTime(), 0.1f, 5f);
        }
        CalculateVelocity();
        CameraBody.Target += Velocity;

    }

}
