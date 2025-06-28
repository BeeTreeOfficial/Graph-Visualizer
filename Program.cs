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
        graph.AddConnection("A", "B");
        graph.AddConnection("B", "C");
        graph.AddConnection("B", "D");
        graph.AddConnection("B", "E");
        graph.AddConnection("C", "E");
        graph.AddConnection("D", "E");
        graph.AddConnection("X", "C");
        graph.AddConnection("X", "E");
        graph.AddConnection("X", "A");

        graph.Print();
        Dictionary<string, double> dict = graph.SolveDijkstra("A");
        Print(dict);

        while (!Raylib.WindowShouldClose()) {
            camera.Update();
            if (Raylib.IsKeyPressed(KeyboardKey.R)) {
                graph.Shuffle();
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
        Console.WriteLine("The Problem Is Solved Successfully:\n------------------------------------------------------------------------------------------------");
        foreach (var item in points)
        {
            Console.WriteLine("___________________________________________________ \n");
            Console.Write($"The Point is Named: {item.Key} || Shortest Distance Is: {Math.Floor(item.Value)}\n");
            Console.WriteLine();
        }
        Console.WriteLine("___________________________________________________ \n");
        Console.WriteLine("------------------------------------------------------------------------------------------------");
    }

}
