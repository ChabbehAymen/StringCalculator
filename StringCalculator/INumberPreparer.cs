namespace StringCalculator;

public interface INumbersPreparer
{
    int[] SplitNumbers(string expression, char[] splitters);
    int[] GetNumbers(string expression);
}