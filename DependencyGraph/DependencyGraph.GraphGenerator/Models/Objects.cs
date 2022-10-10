using Newtonsoft.Json;

namespace DependencyGraph.GraphGenerator.Models
{
    public class Objects
    {
        public string ClassName { get; set; }
        [JsonIgnore]
        public string FilePath { get; set; }
        public List<Objects> Children { get; set; }
    }
}
