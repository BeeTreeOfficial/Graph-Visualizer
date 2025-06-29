using Raylib_cs;


namespace DijkstraAlgorithm;


public class Program
{
    private static bool IsTyping = false;
    public static readonly HashSet<KeyboardKey> SpecialKeys = [KeyboardKey.Enter, KeyboardKey.LeftShift, KeyboardKey.Backspace, KeyboardKey.Space];
    public readonly static Random random = new();
    private static FlyingCamera camera = new(new(0, 0), 1, 1);
    public static void Main()
    {
        string buffer = "";
        Raylib.InitWindow(800, 800, "Dijkstra Algorithm");
        Raylib.SetTargetFPS(60);
        Graph graph = new();
        while (!Raylib.WindowShouldClose())
        {

            KeyboardKey pressedKey = (KeyboardKey)Raylib.GetKeyPressed();
            TypingCheck(pressedKey, ref buffer);
            if (!IsTyping)
            {
                camera.Update();
                FullScreen(pressedKey);
            }
            if (pressedKey == KeyboardKey.Enter)
            {
                HandleCommands(ref buffer, graph);
            }
            if (pressedKey == KeyboardKey.P && !IsTyping)
            {
                graph.Print();
            }
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);
            Raylib.BeginMode2D(camera.GetBody());
            graph.Draw();
            Raylib.EndMode2D();
            Raylib.DrawText(buffer + '_', 2, Raylib.GetScreenHeight() - 35, 35, Color.Black);
            Raylib.EndDrawing();

        }
    }

    private static void HandleCommands(ref string buffer, Graph graph)
    {
        string[] commands = buffer.Split(" ");
        buffer = buffer.Trim();
        if (commands.Contains("DEL"))
        {
            graph.RemovePoint(commands[1]);
        }
        else if (commands.Contains("ADD"))
        {
            switch (commands.Length)
            {
                case 2:
                    graph.AddToPoints(new(commands[1], camera.GetBody().Target));
                    break;
                case 3:
                    graph.AddToPoints(
                        new(commands[1], camera.GetBody().Target,
                        commands[2]));
                    break;
                default:
                    break;
            }
        }
        else if (commands.Contains("CON"))
        {
            switch (commands.Length)
            {
                case 3:
                    graph.CreateConnection(commands[1], commands[2]);
                    break;
                default:
                    break;
            }
        }
        buffer = "";

    }
    private static void TypingCheck(KeyboardKey pressedKey, ref string buffer)
    {
        if (IsTyping)
        {
            switch (pressedKey)
            {
                case KeyboardKey.Null:
                    break;
                case KeyboardKey.Tab:
                    buffer = "";
                    break;
                case KeyboardKey.Delete:
                    buffer = "";
                    break;
                case KeyboardKey.Space:
                    buffer += " ";
                    break;
                case KeyboardKey.Backspace:
                    if (buffer != "")
                    { buffer = buffer[..^1]; }
                    break;
                default:
                    if (!SpecialKeys.Contains(pressedKey))
                    {
                        buffer += pressedKey.ToString();
                    }
                    break;
            }
        }
        if (pressedKey == KeyboardKey.Tab)
        {
            IsTyping = !IsTyping;
        }
    }
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
    public static void Print(Dictionary<string, double> points)
    {
        Console.WriteLine($"The Problem Is Solved Successfully:\n{WritingConstants.HugeDash};");
        foreach (var item in points)
        {
            Console.WriteLine(WritingConstants.UnderDash);
            Console.Write($"The Point is Named: {item.Key} || Shortest Distance Is: {Math.Floor(item.Value)}\n");
            Console.WriteLine();
        }
        Console.WriteLine(WritingConstants.HugeDash); ;
    }

}
