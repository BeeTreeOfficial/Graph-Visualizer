using Raylib_cs;
using System.Linq;
using System.Numerics;


namespace DijkstraAlgorithm;


public class Program
{
    private static bool IsTyping = false;
    private static Point? SelectedPoint = null;
    public static readonly HashSet<KeyboardKey> SpecialKeys = [KeyboardKey.Enter, KeyboardKey.LeftShift, KeyboardKey.Backspace, KeyboardKey.Space];
    public readonly static Random random = new();
    private static FlyingCamera camera = new(new(0, 0), 1, 1);
    public static void Main()
    {
        string buffer = "";
        Raylib.InitWindow(800, 800, "Dijkstra Algorithm");
        Graph graph = new();
        Graph? RecentGraph = GraphManager.Load("RECENT");

        if (RecentGraph != null)
        {
            graph = RecentGraph;
        }

        while (!Raylib.WindowShouldClose())
        {

            KeyboardKey pressedKey = (KeyboardKey)Raylib.GetKeyPressed();
            TypingCheck(pressedKey, ref buffer);
            if (!IsTyping)
            {
                if (SelectedPoint != null)
                {
                    SelectedPoint.Update();
                }
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
            if (SelectedPoint != null)
            {
                SelectedPoint.DrawHighlight();
            }
            Raylib.EndMode2D();
            Raylib.DrawText(buffer + '_', 2, Raylib.GetScreenHeight() - 35, 35, Color.Black);
            Raylib.DrawFPS(5,5);
            Raylib.EndDrawing();

        }
        GraphManager.Save(graph, "RECENT");
    }

    private static void HandleCommands(ref string buffer, Graph graph)
    {
        string[] commands = buffer.Split(" ");
        if (commands.Contains("DEL"))
        {
            if (commands.Length == 2)
            {
                graph.RemovePoint(commands[1]);
                if (SelectedPoint != null && SelectedPoint.Name == commands[1])
                {
                    SelectedPoint = null;
                }
            }
            else if (commands.Length == 3)
            {
                graph.RemoveEdgeByName(commands[1], commands[2]);
                graph.RemoveEdgeByName(commands[2], commands[1]);
            }
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
        else if (commands.Contains("DEX"))
        {
            DijkstraSolve DijkstraSolver = new(graph);
            try
            {
                Print(DijkstraSolver.Solve(commands[1]));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        else if (commands.Contains("RAND"))
        {
            graph.Shuffle();

        }
        else if (commands.Contains("SEL"))
        {
            if (commands.Length == 1)
            {
                SelectedPoint = null;
            }
            else
            {
                SelectedPoint = graph.GetPoint(commands[1]);
                IsTyping = false;
            }
        }
        else if (commands.Contains("SAVE"))
        {
            if (commands.Length == 2)
            {
                GraphManager.Save(graph, commands[1]);
            }
        }
        else if (commands.Contains("LOAD"))
        {
            if (commands.Length == 2)
            {
                Graph? LoadedGraph = GraphManager.Load(commands[1]);
                if (LoadedGraph != null)
                {
                    graph = LoadedGraph;
                }
            }
        }
        else if (commands.Contains("BELL"))
        {
            BellFord bell = new BellFord(graph, commands[1]);
            Dictionary<string, ResultData> bel = bell.Solve();
            Print(bel);
        }
        else if (commands.Contains("NEW"))
        {
            graph.points.Clear();
            graph.edges.Clear();
            Console.WriteLine("Graph Is Cleared");
        }
        else if (commands.Contains("ABC"))
        {
            graph.AddToPoints(new("A"));
            graph.AddToPoints(new("B"));
            graph.AddToPoints(new("C"));
            graph.AddToPoints(new("D"));
            graph.AddToPoints(new("E"));
            graph.Shuffle();
            
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
    public static void Print(Dictionary<string, ResultData> points)
    {
        Console.WriteLine($"The Problem Is Solved Successfully:\n{WritingConstants.HugeDash};");
        foreach (var item in points)
        {
            string Path = "";
            foreach (var point in DijkstraSolve.GetPathToPoint(points, item.Key))
            {
                Path += point;
            }
            Console.WriteLine(WritingConstants.UnderDash);
            Console.Write($"The Point is Named: {item.Key} || Shortest Distance Is: {Math.Floor(item.Value.Price)} and The Path To It Equals {Path}\n");
            Console.WriteLine();
        }
        Console.WriteLine(WritingConstants.HugeDash); ;
    }

}
