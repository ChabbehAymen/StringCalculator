namespace StringCalculator;

public interface INumbersSplitter
{
    int[] Split(string numbers, char[] splitters);
    int[] ExtractNumbers(string expression, string[] delimiters);
}