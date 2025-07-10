using Raylib_cs;
using System.Text;

namespace DijkstraAlgorithm.CommandLines;

public class CommandLine
{
    public bool IsTyping = false;
    public StringBuilder buffer = new();
    public readonly HashSet<KeyboardKey> SpecialKeys = [KeyboardKey.Enter, KeyboardKey.LeftShift, KeyboardKey.Backspace, KeyboardKey.Space, KeyboardKey.Tab];
    private void ConsoleWrite(KeyboardKey pressedKey, State State)
    {
        if (pressedKey == KeyboardKey.Tab) IsTyping = !IsTyping;
        if (!IsTyping || pressedKey == KeyboardKey.Null) return;
        switch (pressedKey)
        {
            case KeyboardKey.Enter:
                CommandsParser.Execute(buffer, ref IsTyping, State);
                buffer.Clear();
                break;
            case KeyboardKey.Space:
                buffer.Append(' ');
                break;
            case KeyboardKey.Backspace:
                if (buffer.Length > 0)
                { buffer.Remove(buffer.Length - 1, 1); }
                break;
            default:
                if (SpecialKeys.Contains(pressedKey)) break;
                buffer.Append((char)pressedKey);
                break;
        }

    }
    public void Update(KeyboardKey KeyPressed, State State)
    {
        ConsoleWrite(KeyPressed, State);
    }
    public void Draw()
    {
        Raylib.DrawText(buffer.ToString() + '_', 2, Raylib.GetScreenHeight() - 35, 35, Color.White);
    }
}
