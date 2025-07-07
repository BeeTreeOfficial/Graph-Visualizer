using Raylib_cs;

using DijkstraAlgorithm.Cameras;
using DijkstraAlgorithm.Graphs;
using DijkstraAlgorithm.Graphs.Points;
using DijkstraAlgorithm.CommandLines;
using DijkstraAlgorithm.Commands;
using DijkstraAlgorithm.Draw;
using DijkstraAlgorithm.Persistence;

namespace DijkstraAlgorithm;
public class Program
{
    private static Graph graph = new();
    public static Graph Graph { get { return graph; } }
    public static IPoint SelectedPoint = EmptyPoint.Instance;
    public static Camera Camera = new(1000);
    public static CommandLine commandLine = new();
    public static CommandDeque commandDeque = new();
    public static void Main()
    {
        int WindowWidth = 1100;
        int WindowHeight = 800;

        int TargetFps = 500;

        string DefaultSaveFile = "Recent";

        float CameraSpeed = 1;

        Drawing.Init(WindowWidth, WindowHeight, TargetFps);
        Console.Clear();
        Storage.Load(DefaultSaveFile);

        while (!Raylib.WindowShouldClose())
        {
            commandLine.Update();
            KeyboardKey pressedKey = (KeyboardKey)Raylib.GetKeyPressed();
            if (!commandLine.IsTyping)
            {
                if (pressedKey == KeyboardKey.Z) commandDeque.Undo();
                if (pressedKey == KeyboardKey.F) Drawing.ToggleFullScreen();
                SelectedPoint.Update();
                Camera.Update();
            }
            Drawing.Draw(graph, SelectedPoint, commandLine, Camera.Body);
        }
        Storage.Save(DefaultSaveFile, graph);
    }
}
