using DijkstraAlgorithm.StructsRelated;

namespace DijkstraAlgorithm;

public class OutputBuffer
{
    public static List<Result> body = new();
    public static List<Result> Body { get { return body; } }
    public void Add(Result result)
    {
        body.Add(result);
    }

}
