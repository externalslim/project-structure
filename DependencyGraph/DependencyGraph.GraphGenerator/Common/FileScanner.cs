namespace DependencyGraph.GraphGenerator.Common
{
    public class FileScanner
    {
        private static List<string> filePaths = new List<string>();

        public static List<string> FilePaths
        {
            get { return filePaths; }
        }

        public static void Scan(List<string> path)
        {
            foreach (var file in path)
            {
                var files = Directory.GetFiles(file);
                if (files != null)
                {
                    var csprojFile = files.Where(x => x.EndsWith("csproj")).FirstOrDefault();
                    if (csprojFile != null)
                    {
                        filePaths.Add(csprojFile);
                    }
                }
            }

        }
    }
}
