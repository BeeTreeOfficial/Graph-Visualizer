using System;
using Raylib_cs;

using DijkstraAlgorithm.Cameras;
using DijkstraAlgorithm.Graphs;
using DijkstraAlgorithm.Graphs.Points;
using DijkstraAlgorithm.CommandLines;
using DijkstraAlgorithm.Commands;

namespace DijkstraAlgorithm;
public class Program
{



    private static Graph graph = new();
    public static Graph Graph { get { return graph; } }
    public static Point? SelectedPoint = null;
    public static FlyingCamera Camera = new(new(0, 0), 1, 1);
    public static CommandLine commandLine = new();
    public static CommandDeque commandDeque = new();
    public static void Main()
    {   
        Draw.Drawing.Init(1100, 800);
        Raylib.SetTargetFPS(120);
        Persistence.Load.LoadFromFile("RECENT");
        while (!Raylib.WindowShouldClose())
        {
            commandLine.Update();
            KeyboardKey pressedKey = (KeyboardKey)Raylib.GetKeyPressed();
            if (!commandLine.IsTyping)
            {
                if (Raylib.IsKeyPressed(KeyboardKey.Z)) commandDeque.Undo();
                if (pressedKey == KeyboardKey.F) Draw.Drawing.ToggleFullScreen();
                SelectedPoint?.Update();
                Camera.Update();
            }
            Draw.Drawing.Draw(graph, SelectedPoint, commandLine, Camera.GetBody());
        }
        Persistence.Save.SaveGraphTo(graph, "Recent");
    }


    public readonly static Random random = new();



}
