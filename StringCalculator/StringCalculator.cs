
using StringCalculator.DelimiterSpecifications;
using System.Runtime.CompilerServices;

namespace StringCalculator;

public partial class StringCalculator
{
    ExpressionHandler expressionHandler;
    int invocationCount = 0;

    public event Action<string, int> AddOccurred;

    public StringCalculator(ExpressionHandler expressionHandler)
    {
        this.expressionHandler = expressionHandler;
    }

    public int Add(string expression, IDelimiterSpecification delimiterSpecification)
    {
        invocationCount++;
        AddOccurred?.Invoke(expression, invocationCount);
        if (string.IsNullOrEmpty(expression)) return 0;
        expressionHandler.SetExpression(expression);
        var numbers = delimiterSpecification.GetNumbers(expressionHandler);
        return Sum(numbers);
    }

    private int Sum(int[] numbers)
    {

        var sum = numbers.Sum();
        var excludedNumbers = numbers.Where(n => n > 1000).ToList();
        foreach (var number in excludedNumbers) { sum -= number; }
        return sum;
    }

    public StringCalculator SplitWith(char splitter)
    {
        expressionHandler.IncludeSplitter(splitter);
       return this;
    }

    public int GetCalledCount()
    {
        return invocationCount;
    }
}
