using DijkstraAlgorithm.MathRelated;
using DijkstraAlgorithm.GraphRelated;
using DijkstraAlgorithm;

namespace DijkstraAlgorithm.CommandRelated;

internal class CommandExecutor
{
    public static void Execute(ref string buffer, ref bool IsTyping)
    {
        
        Graph graph = Program.Graph;
        string[] commands = buffer.Split(" ");
        if (commands.Contains("DEL"))
        {
            if (commands.Length == 2)
            {
                graph.RemovePoint(commands[1]);
                if (Program.SelectedPoint != null && Program.SelectedPoint.Name == commands[1]) Program.SelectedPoint = null;
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
                    graph.AddToPoints(new(commands[1], Program.Camera.GetBody().Target));
                    break;
                case 3:
                    graph.AddToPoints(
                        new(commands[1], Program.Camera.GetBody().Target,
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
            try
            {
                Console.WriteLine(Dijkstra.Solve(graph, commands[1]));
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
                Program.SelectedPoint = null;
            }
            else
            {
                Program.SelectedPoint = graph.GetPoint(commands[1]);
            }
            IsTyping = false;
        }
        else if (commands.Contains("BELL"))
        {
            BellFord bell = new(graph, commands[1]);
            Console.WriteLine(bell.Solve());
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
            graph.CreateConnection("A", "B");
            graph.CreateConnection("A", "C");
            graph.CreateConnection("A", "D");
            graph.CreateConnection("B", "C");
            graph.CreateConnection("D", "E");
            graph.Shuffle();
            Program.SelectedPoint = null;
        }
        buffer = "";

    }
}
