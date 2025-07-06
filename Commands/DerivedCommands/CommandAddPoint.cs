using Raylib_cs;
using System.Numerics;

namespace DijkstraAlgorithm.Commands.DerivedCommands;

internal class CommandAddPoint : ICommand
{
    public static readonly Dictionary<string, Color> Colors
        = new Dictionary<string, Color>
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
    private string nameOfPointToAdd;
    private Color? colorToSet;
    private Vector2? PositionToAddIn;

    public CommandAddPoint(string nameOfPointToAdd, string? color = null, Vector2? Position = null)
    {
        this.nameOfPointToAdd = nameOfPointToAdd;
        byte[] randcolor = [0,0,0];
        Random random = new Random();
        random.NextBytes(randcolor);
        colorToSet = new(randcolor[0], randcolor[1], randcolor[2]);
        if (color != null) if (Colors.TryGetValue(color, out Color Color)) colorToSet = Color;
        if (Position != null) PositionToAddIn = Position;
    }
    public CommandAddPoint(string nameOfPointToAdd, Color color, Vector2? Position = null)
    {
        this.nameOfPointToAdd = nameOfPointToAdd;
        this.colorToSet = color;
        if (Position != null) PositionToAddIn = Position;
    }
    public void Execute()
    {
            Program.Graph.AddToPoints(new(nameOfPointToAdd, PositionToAddIn, colorToSet));
    }
    public void Undo()
    {
        if (nameOfPointToAdd == null) return;
        Program.Graph.RemovePoint(nameOfPointToAdd);
    }
}
