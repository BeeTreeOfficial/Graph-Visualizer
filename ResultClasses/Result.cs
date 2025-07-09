
namespace DijkstraAlgorithm.ResultClasses;

public class Result : IFormattable
{
    public Dictionary<string, ResultData> Body;
    public Result()
    {
        Body = [];
    }

    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        string result = string.Empty;
        if (Body == null) return result;
        foreach (var (Name, Data) in Body)
        {
            if (Data.Price == 0) continue;
            result += $"{Name} is {Math.Round(Data.Price)} pixels far.\n" +
                $"      " +
                "The Path is ";
            string? CurrentLastPoint = Data.PreviousPoint;
            while (!string.IsNullOrEmpty(CurrentLastPoint))
            {
                if (string.IsNullOrEmpty(Body[CurrentLastPoint].PreviousPoint))
                {
                    result += CurrentLastPoint;
                    CurrentLastPoint = Body[CurrentLastPoint].PreviousPoint;
                    continue;
                }
                result += $"{CurrentLastPoint} <- ";
                CurrentLastPoint = Body[CurrentLastPoint].PreviousPoint;
            }
            result += ";\n";
        }
        return result;
    }
}
