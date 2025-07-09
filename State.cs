using DijkstraAlgorithm.Graphs;
using DijkstraAlgorithm.Cameras;
using DijkstraAlgorithm.CommandLines;
using DijkstraAlgorithm.Commands;
using DijkstraAlgorithm.Graphs.Points;
using DijkstraAlgorithm.Interfaces;

namespace DijkstraAlgorithm;

public class State
{
    public State()
    {
        Graph = new();
        SelectedPoint = EmptyPoint.Instance;
        CommandLine = new CommandLine();
        CommandDeque = new CommandDeque();
        Camera ??= new Camera(100);
    }
    public State(float Speed = 100) : this()
    {
        Camera = new Camera(Speed);
    }
    public Graph Graph { get; set; }
    public IPoint SelectedPoint { get; set; }
    public ICamera Camera { get; set; }
    public CommandLine CommandLine { get; set; }
    public CommandDeque CommandDeque { get; set; }
}
