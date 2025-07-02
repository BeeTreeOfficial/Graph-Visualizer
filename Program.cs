using Raylib_cs;

using DijkstraAlgorithm.CameraRelated;
using DijkstraAlgorithm.GraphRelated;
using DijkstraAlgorithm.GraphRelated.Points;
using DijkstraAlgorithm.CommandRelated;

namespace DijkstraAlgorithm;
public class Program
{
    private static Point? selectedPoint = null;
    public static Point? SelectedPoint { get { return selectedPoint; } set { selectedPoint = value; } }

    private static FlyingCamera camera = new(new(0, 0), 1, 1);
    public static FlyingCamera Camera { get { return camera; } }

    private static CommandLine commandLine = new();

    private static Graph graph = new();
    public static Graph Graph { get { return graph; } }
    public static void Main()
    {
        Console.Title = "INFO CONSOLE";
        Raylib.InitWindow(1100, 800, "Dijkstra Algorithm");

        while (!Raylib.WindowShouldClose())
        {
            commandLine.Update();
            KeyboardKey pressedKey = (KeyboardKey)Raylib.GetKeyPressed();

            if (!commandLine.IsTyping)
            {
                SelectedPoint?.Update();
                camera.Update();
                FullScreen(pressedKey);
            }
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);
            Raylib.BeginMode2D(camera.GetBody());
            graph.Draw();
            SelectedPoint?.DrawHighlight();
            Raylib.EndMode2D();
            commandLine.Draw();
            Raylib.DrawFPS(5, 5);
            Raylib.EndDrawing();
        }
    }


    public readonly static Random random = new();

    private static void FullScreen(KeyboardKey pressedKey)
    {
        if (pressedKey == KeyboardKey.F)
        {
            if (Raylib.IsWindowFullscreen())
            {
                Raylib.SetWindowSize(800, 800);
            }
            else { Raylib.SetWindowSize(1920, 1080); }
            Raylib.ToggleFullscreen();
        }
    }


}
