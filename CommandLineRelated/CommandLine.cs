using Raylib_cs;

namespace DijkstraAlgorithm.CommandLineRelated;

public class CommandLine
{
    public bool IsTyping = false;
    public string buffer = "";
    public readonly HashSet<KeyboardKey> SpecialKeys = [KeyboardKey.Enter, KeyboardKey.LeftShift, KeyboardKey.Backspace, KeyboardKey.Space, KeyboardKey.Tab];
    private void ConsoleWrite(KeyboardKey pressedKey)
    {
        if (pressedKey == KeyboardKey.Tab) IsTyping = !IsTyping;
        if (!IsTyping || pressedKey == KeyboardKey.Null) return;
        switch (pressedKey)
        {
            case KeyboardKey.Enter:
                CommandsParser.Execute(ref buffer, ref IsTyping);
                buffer = "";
                break;
            case KeyboardKey.Space:
                buffer += " ";
                break;
            case KeyboardKey.Backspace:
                if (buffer != "")
                { buffer = buffer[..^1]; }
                break;
            default:
                if (SpecialKeys.Contains(pressedKey)) break;
                buffer += (char)pressedKey;
                break;
        }

    }
    public void Update()
    {
        ConsoleWrite((KeyboardKey)Raylib.GetKeyPressed());
    }
    public void Draw()
    {
        Raylib.DrawText(buffer + '_', 2, Raylib.GetScreenHeight() - 35, 35, Color.Black);
    }
}
