namespace StringCalculator;

public class StringCalculator
{
    int invocationCount = 0;
    INumbersPreparer numbersPreparer;
    
    public event Action<string, int> AddOccurred;

    public StringCalculator(INumbersPreparer numbersPreparer)
    {
        this.numbersPreparer = numbersPreparer;
    }

    public int Add(string numbers, char[] splitters)
    {
        if (string.IsNullOrEmpty(numbers)) return 0;
        invokeCall(numbers);
        var entierNumbers = numbersPreparer.SplitNumbers(numbers, splitters);
        return Sum(entierNumbers);
    }
    
    void invokeCall(string input)
    {
        invocationCount++;
        AddOccurred?.Invoke(input, invocationCount);
    }

    public int Add(string expression)
    {
        if (string.IsNullOrEmpty(expression)) return 0;
        invokeCall(expression);
        var entierNumbers = numbersPreparer.GetNumbers(expression);
        return Sum(entierNumbers);
    }

    private int Sum(int[] numbers)
    {

        var sum = numbers.Sum();
        var excludedNumbers = numbers.Where(n => n > 1000).ToList();
        foreach (var number in excludedNumbers) { sum -= number; }
        return sum;
    }

    public int GetAddCallCount()
    {
        return invocationCount;
    }
}
