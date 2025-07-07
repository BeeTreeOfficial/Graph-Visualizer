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
    public static void Main()
    {
        int WindowWidth = 1100;
        int WindowHeight = 800;

        int TargetFps = 5000;

        string DefaultSaveFile = "Recent";

        float CameraSpeed = 1;

        Drawing.Init(WindowWidth, WindowHeight, TargetFps);
        Console.Clear();

        State CurrentState = new();
        CurrentState.Camera.Speed = CameraSpeed;
        CurrentState = Storage.Load(DefaultSaveFile);
        while (!Raylib.WindowShouldClose())
        {
            KeyboardKey pressedKey = (KeyboardKey)Raylib.GetKeyPressed();
            CurrentState.CommandLine.Update(pressedKey, CurrentState);
            if (!CurrentState.CommandLine.IsTyping)
            {
                if (pressedKey == KeyboardKey.Z) CurrentState.CommandDeque.Undo(CurrentState);
                if (pressedKey == KeyboardKey.F) Drawing.ToggleFullScreen();
                CurrentState.SelectedPoint.Update();
                CurrentState.Camera.Update();
            }
            Drawing.Draw(CurrentState);
        }
        Storage.Save(DefaultSaveFile, CurrentState);


    }
}
