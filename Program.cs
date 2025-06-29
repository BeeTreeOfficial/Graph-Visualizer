using Raylib_cs;
using System.Runtime.CompilerServices;


namespace DijkstraAlgorithm;


public partial class Program
{
    public readonly static Random random = new();
    public static void Main()
    {
        FlyingCamera camera = new(new(0,0), 1, 1);
        Raylib.InitWindow(800, 800, "LOL");
        Graph graph = new();
        graph.AddToPoints(new("A"));
        graph.AddToPoints(new("B"));
        graph.AddToPoints(new("C"));
        graph.AddToPoints(new("D"));
        graph.AddToPoints(new("E"));
        graph.AddToPoints(new("X"));

        while (!Raylib.WindowShouldClose()) {
            camera.Update();
            if (Raylib.IsKeyPressed(KeyboardKey.R)) {
                string answer = Console.ReadLine();
                graph.CreateConnection(answer[0].ToString(), answer[1].ToString());
                Print(graph.SolveDijkstra("A"));
            }
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);
            Raylib.BeginMode2D(camera.GetBody());
            graph.Draw();
            Raylib.EndMode2D();
            Raylib.EndDrawing();
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
