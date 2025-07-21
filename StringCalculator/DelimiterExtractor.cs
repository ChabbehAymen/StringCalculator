namespace StringCalculator;

public class DelimiterExtractor : IDelimiterExtractor
{
    IExtractor extractor;

    public DelimiterExtractor(IExtractor extractor)
    {
        this.extractor = extractor;
    }

    public string[] ExtractDelimiter(string expression)
    {
        return extractor.ExtractDelimiter(expression);
    }

    public string[] ExtractMultiDelimiters(string expression)
    {
        return extractor.ExtractDelimiters(expression);
    }
}