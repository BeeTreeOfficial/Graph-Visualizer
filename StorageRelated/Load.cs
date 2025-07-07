using Raylib_cs;

using DijkstraAlgorithm.Commands.DerivedCommands;
using DijkstraAlgorithm.Graphs;

namespace DijkstraAlgorithm.Persistence;
public partial class Storage
{
    public static State Load(string path)
    {
        State LoadedState = new();
        LoadedState.Camera.Speed = 300;
        if (!File.Exists(path)) return LoadedState;
        string DataRetreived = File.ReadAllText(path);
        string[] Content = DataRetreived.Split("\n");
        foreach (var Line in Content)
        {
            string[] Arguments = Line.Split(" ");
            if (Arguments[0] == "Point:" && Arguments.Length >= 7)
            {
                string Name = Arguments[1];
                float x = float.Parse(Arguments[2]);
                float y = float.Parse(Arguments[3]);
                Color color = Color.Red;
                color.R = (byte)float.Parse(Arguments[4][3..]);
                color.G = (byte)float.Parse(Arguments[5][2..]);
                color.B = (byte)float.Parse(Arguments[6][2..]);
                LoadedState.CommandDeque.Execute(new CommandAddPoint(Name, color, new(x, y)), LoadedState);
            }
            if (Arguments[0] == "Edge:" && Arguments.Length >= 3)
            {
                LoadedState.CommandDeque.Execute(new CommandCreateConnection(Arguments[1], Arguments[2]), LoadedState);
            }
        }
        return LoadedState;
    }
}
