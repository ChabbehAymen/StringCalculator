using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace StringCalculator;

public class NumbersHandler
{
    const string NumbersRegex = @"\n(.+)";
    
    string numbers = "";
    List<string> splattedNumbers;

    public NumbersHandler()
    {
        splattedNumbers = new List<string>();
    }

    public void SetNumbers(string expression, bool extractNumbers = false) 
    {
        if (extractNumbers) ExtractNumbers(expression);
        else numbers = expression;
    }

    void ExtractNumbers(string expression) 
    {
        var match = Regex.Match(expression, NumbersRegex);
        if (!match.Success) throw new ArgumentException($"Invalid Numbers: {this.numbers}");
        numbers = match.Groups[1].Value;
    }

    public NumbersHandler SplitNumbers(char[] delimiters) 
    {
        splattedNumbers.AddRange(numbers.Split(delimiters));
        return this;
    }

    public int[] ParseNumbers() 
    {
        var parsedNumbers = splattedNumbers.Select(ParseNumber).ToList();
        var negativeNumbers = parsedNumbers.Where(number => number < 0).ToArray();

        if (negativeNumbers.Length > 0) throw new ArgumentException($"Negatives not allowed: [{string.Join(", ", negativeNumbers)}]");
        return parsedNumbers.ToArray();
    }


    int ParseNumber(string number)
    {
        if (int.TryParse(number, out var intNumber)) return intNumber;
        throw new ArgumentException($"Unexpected Number: {number}");
    }
}
