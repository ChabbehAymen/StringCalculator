using System.Text.RegularExpressions;

namespace StringCalculator;

public class RegexExtractor : IExtractor 
{
    const string NumbersPattern = @"\n(.+)";
    const string SingleDelimiterPattern = @"//(.)";
    private const string MultiDelimitersPattern = @"\[(.+?)\]";
    public string ExtractNumbers(string expression)
    {
        var match = Extract(expression, NumbersPattern);
        return GetValues(match).First();
    }
    
    MatchCollection Extract(string expression, string pattern)
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
    
    private List<string> GetValues(MatchCollection matchCollection)
    {
        return matchCollection.Select(m => m.Groups[1].Value).ToList();
    }


    public string[] ExtractDelimiter(string expression)
    {
        var matches = Extract(expression, SingleDelimiterPattern);
        return GetValues(matches).ToArray();
    }

    public string[] ExtractDelimiters(string expression)
    {
        var matches = Extract(expression, MultiDelimitersPattern);
        return GetValues(matches).ToArray();
    }

}