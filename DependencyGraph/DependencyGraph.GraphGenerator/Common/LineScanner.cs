using DependencyGraph.GraphGenerator.Helper;
using DependencyGraph.GraphGenerator.Models;

namespace DependencyGraph.GraphGenerator.Common
{
    public class LineScanner
    {

        public static Objects Scan(string filePath, Objects @object = null, List<string> files = null)
        {
            Objects objectInner = @object == null ? new Objects() : @object;
            objectInner.ClassName = TextHelper.toStringFormat(filePath);
            objectInner.FilePath = filePath;
            var children = new List<Objects>();
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                if (line.Contains("ProjectReference"))
                {
                    var child = new Objects();
                    var exactLine = files.Where(x => x.Contains(TextHelper.toStringFormat(line))).FirstOrDefault();
                    child.ClassName = TextHelper.toStringFormat(exactLine);
                    child.FilePath = exactLine;
                    children.Add(child);
                }
            }

            objectInner.Children = children;

            if (objectInner.Children.Count > 0)
            {
                foreach (var item in objectInner.Children)
                {
                    Scan(item.FilePath, item, files);
                }
            }

            return objectInner;
        }
    }
}
