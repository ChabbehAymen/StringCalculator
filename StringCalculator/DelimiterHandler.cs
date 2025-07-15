


using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace StringCalculator;

public class DelimiterHandler
{
    List<char> splitters;
    private const string DelimiterRegex = @"//(.)";

    public DelimiterHandler()
    {
        this.splitters = new();
    }

    public void Include(char splitter)
    {
        splitters.Add(splitter);
    }

    public char[] GetDelimiters()
    {
        if(splitters.Count > 0) { 
            var splitterChars = splitters.ToArray();
            splitters.Clear();
            return splitterChars;
        }
        return [','];
    }

     public void SetDelimiterFromExpression(string expression)
    {
        Match match = Regex.Match(expression, DelimiterRegex);
        var delimiter = ParseDelimiter(match.Groups[1].Value);
        splitters.Add(delimiter);
    }

    private char ParseDelimiter(string value)
    {
        if (!char.TryParse(value, out var delimiter)) throw new ArgumentException($"Unsupported Delimiter: {value}");
        return delimiter;
    }
}