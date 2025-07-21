namespace StringCalculator;

public interface IDelimiterExtractor
{
    string[] ExtractDelimiter(string expression);
    string[] ExtractMultiDelimiters(string expression);
}