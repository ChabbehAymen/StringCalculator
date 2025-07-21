namespace StringCalculator;

public class NumbersPreparer : INumbersPreparer
{
    INumbersSplitter splitter;
    private IDelimiterExtractor delimiterExtractor;

    public NumbersPreparer(INumbersSplitter splitter, IDelimiterExtractor delimiterExtractor)
    {
        this.splitter = splitter;
        this.delimiterExtractor = delimiterExtractor;
    }
    public int[] SplitNumbers(string numbers, char[] splitters)
    {
        return splitter.Split(numbers, splitters);
    }

    public int[] GetNumbers(string expression)
    {
        string[] delimiters;
        delimiters = expression.Contains('[') 
            ? delimiterExtractor.ExtractMultiDelimiters(expression) 
            : delimiterExtractor.ExtractDelimiter(expression);
        return splitter.ExtractNumbers(expression, delimiters);
    }
}
