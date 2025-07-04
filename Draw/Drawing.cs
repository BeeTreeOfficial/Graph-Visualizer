using Raylib_cs;

using DijkstraAlgorithm.CommandLines;
using DijkstraAlgorithm.Graphs;
using DijkstraAlgorithm.Graphs.Points;

namespace DijkstraAlgorithm.Draw;

internal static class Drawing
{
    public static void Init(int x, int y)
    {
        Raylib.InitWindow(x, y, "Dijkstra Algorithm");
    }
    public static void Draw(Graph Graph, Point? SelectedPoint, CommandLine commandLine, Camera2D Camera)
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.White);
        Raylib.BeginMode2D(Camera);
        Graph.Draw();
        SelectedPoint?.DrawHighlight();
        Raylib.EndMode2D();
        commandLine.Draw();
        Raylib.DrawFPS(5, 5);
        Raylib.EndDrawing();
    }

    public static void ToggleFullScreen()
    {

        if (Raylib.IsWindowFullscreen())
        {
            Raylib.SetWindowSize(800, 800);
        }
        else { Raylib.SetWindowSize(1920, 1080); }
        Raylib.ToggleFullscreen();

    }
}
