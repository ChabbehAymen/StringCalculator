namespace StringCalculator;

public class NumbersSplitter : INumbersSplitter
{
    private IExtractor extractor;

    public NumbersSplitter(IExtractor extractor)
    {
        this.extractor = extractor;
    }

    public int[] Split(string numbers, char[] splitters)
    {
        var splitNumbers = numbers.Split(splitters);
        var entierNumbers = ParseNumbers(splitNumbers);
        return entierNumbers;
    }

    public int[] ExtractNumbers(string expression, string[] delimiters)
    {
        var numbers = extractor.ExtractNumbers(expression);
        var splitNumbers = numbers.Split(delimiters, StringSplitOptions.TrimEntries);
        var entierNumbers = ParseNumbers(splitNumbers);
        return entierNumbers;
    }

    public int[] ParseNumbers(string[] numbers) 
    {
        var parsedNumbers = numbers.Select(ParseNumber).ToList();
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