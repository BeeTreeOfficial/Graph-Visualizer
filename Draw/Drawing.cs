﻿using Raylib_cs;

using DijkstraAlgorithm.CommandLines;
using DijkstraAlgorithm.Graphs;
using DijkstraAlgorithm.Graphs.Points;

namespace DijkstraAlgorithm.Draw;

internal static class Drawing
{
    private static Color BackgroundColor = new(40, 40, 40);
    public static void Init(int x, int y, int TargetFps = 10000)
    {
        Raylib.InitWindow(x, y, "Dijkstra Algorithm");
        Raylib.SetTargetFPS(TargetFps);
    }
    public static void Draw(State State)
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(BackgroundColor);
        Raylib.BeginMode2D(State.Camera.Body);
        State.Graph.Draw();
        State.SelectedPoint.DrawHighlight();
        Raylib.EndMode2D();
        State.CommandLine.Draw();
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
