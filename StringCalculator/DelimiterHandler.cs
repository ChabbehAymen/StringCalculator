using System.Text.RegularExpressions;

namespace StringCalculator;

public class DelimiterHandler
{
    List<char> splitters;
    private const string SingleDelimiterPattern = @"//(.)";
    private const string LargeDelimiterPattern = @"//\[(.+)\]";
    private const string MultiLargeDelimiterPattern = @"//\[(.+)\]";

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
            splitters.Clear(); // ❗ Side effect noted in your TODO
            return splitterChars;
        }
        return [','];
    }

    public void ExtractSingleDelimiter(string expression)
    {
        var match = ExtractDelimiter(expression, SingleDelimiterPattern);
        AddDelimiter(match);
    }

    MatchCollection ExtractDelimiter(string expression, string pattern)
    {
        try
        {
            return Regex.Matches(expression, pattern);
        }
        catch (RegexMatchTimeoutException)
        {
            // Return Empty MatchCollection: Assume that timeout represents no match.
            return Regex.Matches(string.Empty, "a^");
        }
    }

    void AddDelimiter(MatchCollection matches)
    {
        foreach (Match match in matches)
        {
            var strDelimiter = ParseDelimiter(match.Groups[1].Value);
            splitters.Add(strDelimiter);
        }
    }


    char ParseDelimiter(string value)
    {
        if (!char.TryParse(value, out var delimiter)) throw new ArgumentException($"Unsupported Delimiter: {value}");

        return delimiter;
    }

    public void ExtractLargeDelimiter(string expression) 
    {
        var delimiter = ExtractDelimiter(expression, LargeDelimiterPattern);
        AddDelimiter(delimiter);
    }
}