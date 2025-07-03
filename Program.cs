using Raylib_cs;

using DijkstraAlgorithm.CameraRelated;
using DijkstraAlgorithm.GraphRelated;
using DijkstraAlgorithm.GraphRelated.Points;
using DijkstraAlgorithm.CommandLineRelated;
using DijkstraAlgorithm.RenderRelated;
using DijkstraAlgorithm.CommandsRelated;

namespace DijkstraAlgorithm;
public class Program
{
    public static Point? SelectedPoint = null;
    public static FlyingCamera Camera = new(new(0, 0), 1, 1);
    public static CommandLine commandLine = new();
    public static CommandDeque commandDeque = new();
    private static Graph graph = new();
    public static Graph Graph { get { return graph; } }
    public static void Main()
    {
        Renderer.Init(1100, 800);
        Raylib.SetTargetFPS(120);
        while (!Raylib.WindowShouldClose())
        {
            commandLine.Update();
            KeyboardKey pressedKey = (KeyboardKey)Raylib.GetKeyPressed();
            if (!commandLine.IsTyping)
            {
                if (Raylib.IsKeyPressed(KeyboardKey.Z)) commandDeque.Undo();
                if (pressedKey == KeyboardKey.F) Renderer.ToggleFullScreen();
                SelectedPoint?.Update();
                Camera.Update();
            }
            Renderer.Draw(graph, SelectedPoint, commandLine, Camera.GetBody());
        }
    }

    public readonly static Random random = new();



}
