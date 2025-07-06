using DijkstraAlgorithm.Graphs;
using DijkstraAlgorithm.Cameras;
using DijkstraAlgorithm.CommandLines;
using DijkstraAlgorithm.Commands;
using DijkstraAlgorithm.Graphs.Points;

namespace DijkstraAlgorithm;

public class State
{
    private Graph graph;
    public Point? selectedPoint;
    public ICamera camera;
    public CommandLine commandLine;
    public CommandDeque commandDeque;

}
