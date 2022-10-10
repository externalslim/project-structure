namespace DependencyGraph.GraphGenerator.Common
{
    public class DirectoryScanner
    {
        private static List<string> directoryPaths = new List<string>();
        public static List<string> DirectoryPaths
        {
            get { return directoryPaths; }
        }

        public static void Scan(string path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            var directories = directoryInfo.GetDirectories();
            if (directories.Length > 0)
            {
                foreach (var directory in directories)
                {
                    if (
                        !directory.FullName.Contains("bin") &&
                        !directory.FullName.Contains("obj") &&
                        !directory.FullName.Contains(".vs")  &&
                        !directory.FullName.Contains(".git")
                        )
                    {
                        directoryPaths.Add(directory.FullName);
                    }
                    Scan(directory.FullName);
                }
            } 
        }
    }
}
