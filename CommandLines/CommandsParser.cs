using DijkstraAlgorithm.Mathematics;
using DijkstraAlgorithm.Graphs;
using DijkstraAlgorithm.Commands.DerivedCommands;
using DijkstraAlgorithm.Persistence;
using DijkstraAlgorithm.Graphs.Points;
using System.Text;
using DijkstraAlgorithm.Interfaces;

namespace DijkstraAlgorithm.CommandLines;

internal class CommandsParser
{
    public static void Execute(StringBuilder buffer, ref bool IsTyping, State State)
    {
        Graph graph = State.Graph;
        string[] commands = buffer.ToString().Split(" ");
        if (commands.Contains("DEL"))
        {
            if (commands.Length == 2)
            {
                State.CommandDeque.Execute(new CommandDeletePoint(commands[1]), State);
                
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
                    State.CommandDeque.Execute(new CommandAddPoint(commands[1], null, State.Camera.Body.Target), State);
                    break;
                case 3:
                    State.CommandDeque.Execute(new CommandAddPoint(commands[1], commands[2], State.Camera.Body.Target), State);
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
                    State.CommandDeque.Execute(new CommandCreateConnection(commands[1], commands[2]), State);
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
                State.SelectedPoint = EmptyPoint.Instance;
            }
            else
            {
                IPoint? point = graph.GetPoint(commands[1]);
                if (point != null) State.SelectedPoint = point;
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
            Storage.Save(commands[1], State);
        }
        else if (commands.Contains("LOAD") && commands.Length >= 2)
        {
            Storage.Load(commands[1]);
            Console.WriteLine(graph.Points);
        }
        else if (commands.Contains("NEW"))
        {
            State.CommandDeque.Execute(new CommandClearGraph(), State);
        }
        else if (commands.Contains("UNDO"))
        {
            State.CommandDeque.Undo(State);
        }
        buffer.Clear();

    }
}
