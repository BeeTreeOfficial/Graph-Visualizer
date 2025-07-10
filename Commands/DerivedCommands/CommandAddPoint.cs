using Raylib_cs;
using System.Numerics;

namespace DijkstraAlgorithm.Commands.DerivedCommands;

internal class CommandAddPoint : ICommand
{
    public static readonly Dictionary<string, Color> Colors
        = new()
        {
        { "BEIGE",                Color.Beige },
        { "BLACK",                Color.Black },
        { "BLUE",                 Color.Blue },
        { "BROWN",                Color.Brown },
        { "DARKBLUE",             Color.DarkBlue },
        { "DARKGRAY",             Color.DarkGray },
        { "DARKGREEN",            Color.DarkGreen },
        { "GOLD",                 Color.Gold },
        { "GRAY",                 Color.Gray },
        { "GREEN",                Color.Green },
        { "LIGHTGRAY",            Color.LightGray },
        { "LIME",                 Color.Lime },
        { "MAGENTA",              Color.Magenta },
        { "MAROON",               Color.Maroon },
        { "ORANGE",               Color.Orange },
        { "PINK",                 Color.Pink },
        { "PURPLE",               Color.Purple },
        { "RED",                  Color.Red },
        { "SKYBLUE",              Color.SkyBlue },
        { "VIOLET",               Color.Violet },
        { "WHITE",                Color.White },
        { "YELLOW",               Color.Yellow }
        };
    private readonly string nameOfPointToAdd;
    private readonly Color? color;
    private readonly Vector2? PositionToAddIn;
    private readonly int Radius;

    public CommandAddPoint(string nameOfPointToAdd, string? color = null, Vector2? Position = null, int Radius = 10)
    {
        this.nameOfPointToAdd = nameOfPointToAdd;
        byte[] randcolor = [0,0,0];
        Random random = new();
        random.NextBytes(randcolor);
        this.color = new(randcolor[0], randcolor[1], randcolor[2]);
        this.Radius = Radius;
        if (color != null) if (Colors.TryGetValue(color, out Color Color)) this.color = Color;
        if (Position != null) PositionToAddIn = Position;
    }
    public CommandAddPoint(string nameOfPointToAdd, Color color, Vector2? Position = null, int Radius = 10)
    {
        this.nameOfPointToAdd = nameOfPointToAdd;
        this.color = color;
        this.Radius = Radius;
        if (Position != null) PositionToAddIn = Position;
    }
    public void Execute(State State)
    {
            State.Graph.AddToPoints(new(nameOfPointToAdd, Radius, PositionToAddIn, color));
    }
    public void Undo(State State)
    {
        if (nameOfPointToAdd == null) return;
        State.Graph.RemovePoint(nameOfPointToAdd);
    }
}
