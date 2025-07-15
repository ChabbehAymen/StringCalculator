using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace StringCalculator;

public class NumbersHandler
{
    const string NumbersRegex = @"\n(.+)";
    
    string numbers = "";


    public void SetNumbers(string numbers) 
    {
        this.numbers = numbers;
    }

    public void ExtractNumbers(string expression) 
    {
        numbers = GetNumbers(expression);
    }
    string GetNumbers(string expression) 
    {
        var match = Regex.Match(expression, NumbersRegex);
        if (!match.Success) throw new ArgumentException($"Invalid Numbers: {this.numbers}");
        var numbers = match.Groups[1].Value;
        return numbers;
    }

    public string[] SplitNumbers(char[] delimiters) 
    {
        return numbers.Split(delimiters);
    }


}
