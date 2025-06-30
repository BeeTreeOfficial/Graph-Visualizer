using System.Text.Json;

namespace DijkstraAlgorithm;


public static class GraphManager
{
    private static readonly JsonSerializerOptions _opts = new JsonSerializerOptions
    {
        WriteIndented = true
    };

    public static void Save(Graph graph, string SaveFileName)
    {
        try
        {
            string JsonFileToSave = JsonSerializer.Serialize(graph, _opts);
            File.WriteAllText(SaveFileName, JsonFileToSave);
        }
        catch (Exception error)
        {
            Console.WriteLine("Error while saving the file");
            Console.WriteLine(error.Message);
        }
    }

    public static Graph? Load(string SaveFileName)
    {
        try
        {
            Graph? graph = null;
            string JsonLoaded = File.ReadAllText(SaveFileName);
            graph = JsonSerializer.Deserialize<Graph>(JsonLoaded, _opts);
            Console.WriteLine("Loaded File");
            return graph;
        }
        catch (Exception error)
        {
            Console.WriteLine("Error while loading the file");
            Console.WriteLine(error.Message);
            return null;
        }
    }
}

