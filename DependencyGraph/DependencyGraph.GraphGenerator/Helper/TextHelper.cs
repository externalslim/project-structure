namespace DependencyGraph.GraphGenerator.Helper
{
    public class TextHelper
    {
        public static string toStringFormat(string text)
        {
            var splitChar = text.Trim().LastIndexOf("\\") + 1;
            return text
                        .Trim()
                        .Substring(
                                splitChar,
                                text.Trim().Length - splitChar
                                )
                        .Replace("\" />", "");
        }
    }
}
