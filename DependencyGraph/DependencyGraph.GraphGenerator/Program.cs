using DependencyGraph.GraphGenerator.Common;
using DependencyGraph.GraphGenerator.Helper;
using DependencyGraph.GraphGenerator.Models;
using Newtonsoft.Json;

internal class Program
{
    private static void Main(string[] args)
    {
        Dictionary<string, List<string>> keyValuePairs = new Dictionary<string, List<string>>();

        DirectoryScanner.Scan(@"D:\Work\TfsGit\ShellApi");
        var directories = DirectoryScanner.DirectoryPaths;

        FileScanner.Scan(directories);
        var files = FileScanner.FilePaths;

        List<Objects> objects = new List<Objects>();
        foreach (var file in files)
        {

            Objects @object = LineScanner.Scan(file, null, files);
            objects.Add(@object);
        }

        var formattedJson = JsonConvert.SerializeObject(objects, Formatting.None);

        File.WriteAllText(@"D:\Users\vb36786\Desktop\DependencyGraph\DependencyGraph\DependencyGraph.GraphGenerator\jsonpath", formattedJson);

        Console.WriteLine("File generated successfully");
        Thread.Sleep(3000);
        Environment.Exit(1);
    }
}