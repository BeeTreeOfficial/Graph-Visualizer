using Raylib_cs;

using DijkstraAlgorithm.Draw;
using DijkstraAlgorithm.Persistence;

namespace DijkstraAlgorithm;
public class Program
{
    public static void Main()
    {
        int WindowWidth = 1100;
        int WindowHeight = 800;
        
        int TargetFps = 10000; // Max fps cap

        string DefaultSaveFile = "Recent"; // File where the game autosaves

        float DefaultCameraSpeed = 1000; // Default Speed if Another is not Specified

        Drawing.Init(WindowWidth, WindowHeight, TargetFps);
        Console.Clear();

        State CurrentState = Storage.Load(DefaultSaveFile, DefaultCameraSpeed);
        Raylib.SetWindowState(ConfigFlags.ResizableWindow);
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
