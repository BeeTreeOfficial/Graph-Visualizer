using Raylib_cs;
using System.Numerics;

namespace DijkstraAlgorithm.Cameras;

public class Camera: ICamera
{
    public Camera(float CameraSpeed)
    {
        MaxSpeed = CameraSpeed * 1000;
        body = new Camera2D();
        body.Offset.X = Raylib.GetScreenWidth() / 2;
        body.Offset.Y = Raylib.GetScreenHeight() / 2;
        body.Zoom = 1;
    } 
    public Vector2 Position { get { return body.Target; } set {  body.Target = value; } }
    public float MaxSpeed { get;  set; }
    private float CurrentSpeed = 0;
    private Camera2D body;
    public Camera2D Body { get { return body; } }
    public void ZoomUpdate()
    {
        int ZoomDirection = Raylib.IsKeyDown(KeyboardKey.E) - Raylib.IsKeyDown(KeyboardKey.Q);
        body.Zoom += ZoomDirection * Raylib.GetFrameTime() * 2;
        body.Zoom = Math.Clamp(body.Zoom, 0.1f, 5f);
    }
    public void Update()
    {
        ZoomUpdate();
        Vector2 Direction = Vector2.Zero;
        Direction.X = Raylib.IsKeyDown(KeyboardKey.D) - Raylib.IsKeyDown(KeyboardKey.A);
        Direction.Y = Raylib.IsKeyDown(KeyboardKey.S) - Raylib.IsKeyDown(KeyboardKey.W);
        CurrentSpeed = Raylib.GetFrameTime() * MaxSpeed;
        body.Target += CurrentSpeed * Direction;
    }
}
