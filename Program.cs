using Raylib_cs;
using System.Runtime.CompilerServices;


namespace DijkstraAlgorithm;


public partial class Program
{
    public readonly static Random random = new();
    public static void Main()
    {
        FlyingCamera camera = new(new(0,0), 1, 1);
        Raylib.InitWindow(1000, 1000, "LOL");
        Graph graph = new();
        graph.AddToPoints(new("A"));
        graph.AddToPoints(new("B"));
        graph.AddToPoints(new("C"));
        graph.AddToPoints(new("D"));
        graph.AddToPoints(new("E"));
        graph.AddToPoints(new("X"));
        graph.AddConnection("A", 1, "B");
        graph.AddConnection("B", 2, "C");
        graph.AddConnection("B", 2, "D");
        graph.AddConnection("B", 7, "E");
        graph.AddConnection("C", 3, "E");
        graph.AddConnection("D", 4, "E");
        graph.AddOneWayConnection("X", 2, "C");
        graph.AddOneWayConnection("X", 9, "E");
        graph.AddOneWayConnection("X", 10, "A");

        graph.Print();
        Dictionary<string, double> dict = graph.SolveDijkstra("A");
        Print(dict);

        while (!Raylib.WindowShouldClose()) {
            camera.Update();
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
            Console.Write($"The Point is Named: {item.Key} || Shortest Distance Is: {item.Value}\n");
            Console.WriteLine();
        }
        Console.WriteLine("___________________________________________________ \n");
        Console.WriteLine("------------------------------------------------------------------------------------------------");
    }

}
