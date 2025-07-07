using DijkstraAlgorithm.Mathematics;
using DijkstraAlgorithm.Graphs;
using DijkstraAlgorithm.Commands.DerivedCommands;
using DijkstraAlgorithm.Persistence;
using DijkstraAlgorithm.Graphs.Points;

namespace DijkstraAlgorithm.CommandLines;

internal class CommandsParser
{
    public static void Execute(ref string buffer, ref bool IsTyping)
    {
        Graph graph = Program.Graph;
        string[] commands = buffer.Split(" ");
        if (commands.Contains("DEL"))
        {
            if (commands.Length == 2)
            {
                Program.commandDeque.Execute(new CommandDeletePoint(commands[1]));
                
            }
            else if (commands.Length == 3)
            {
                graph.RemoveEdgeByName(commands[1], commands[2]);
            }
        }
        else if (commands.Contains("ADD"))
        {
            switch (commands.Length)
            {
                case 2:
                    Program.commandDeque.Execute(new CommandAddPoint(commands[1], null, Program.Camera.Body.Target));
                    break;
                case 3:
                    Program.commandDeque.Execute(new CommandAddPoint(commands[1], commands[2], Program.Camera.Body.Target));
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
                    Program.commandDeque.Execute(new CommandCreateConnection(commands[1], commands[2]));
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
                Program.SelectedPoint = EmptyPoint.Instance;
            }
            else
            {
                IPoint? point = graph.GetPoint(commands[1]);
                if (point != null) Program.SelectedPoint = point;
            }
            IsTyping = false;
        }
        else if (commands.Contains("BELL") && commands.Length >= 2)
        {
            BellFord bell = new(graph, commands[1]);
            Console.WriteLine(bell.Solve());
        }
        else if (commands.Contains("SAVE") && commands.Length >= 2)
        {
            Storage.Save(commands[1], graph);
        }
        else if (commands.Contains("LOAD") && commands.Length >= 2)
        {
            Storage.Load(commands[1]);
            Console.WriteLine(graph.Points);
        }
        else if (commands.Contains("NEW"))
        {
            Program.commandDeque.Execute(new CommandClearGraph());
        }
        else if (commands.Contains("UNDO"))
        {
            Program.commandDeque.Undo();
        }
            buffer = "";

    }
}
