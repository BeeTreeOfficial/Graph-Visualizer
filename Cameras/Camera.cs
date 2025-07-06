using Raylib_cs;
using System.Numerics;

namespace DijkstraAlgorithm.Cameras;

public class Camera: ICamera
{
    public Camera(float Speed)
    {
        this.Speed = Speed;
        body = new Camera2D();
        body.Offset.X = Raylib.GetScreenWidth() / 2;
        body.Offset.Y = Raylib.GetScreenHeight() / 2;
        body.Zoom = 1;
    }
    private float Speed;
    private Vector2 Velocity;
    private Camera2D body;
    public Camera2D Body { get { return body; } }
    public void ZoomUpdate()
    {
        int ZoomDirection = Raylib.IsKeyDown(KeyboardKey.E) - Raylib.IsKeyDown(KeyboardKey.Q);
        body.Zoom += ZoomDirection * Raylib.GetFrameTime() * 2;
        body.Zoom = Math.Clamp(body.Zoom, 0.1f, 5f);
    }
    private void CalculateVelocity()
    {
        Vector2 Direction = Vector2.Zero;
        Direction.X = Raylib.IsKeyDown(KeyboardKey.D) - Raylib.IsKeyDown(KeyboardKey.A);
        Direction.Y = Raylib.IsKeyDown(KeyboardKey.S) - Raylib.IsKeyDown(KeyboardKey.W);
        Velocity = Direction * (Speed / Body.Zoom) * Raylib.GetFrameTime();
    }
    public void Update()
    {
        ZoomUpdate();
        CalculateVelocity();
        body.Target += Velocity;
    }
}
