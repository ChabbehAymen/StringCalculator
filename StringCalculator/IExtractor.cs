namespace StringCalculator;

public interface IExtractor
{
    string ExtractNumbers(string expression);
    string[] ExtractDelimiter(string expression);
    string[] ExtractDelimiters(string expression);
}