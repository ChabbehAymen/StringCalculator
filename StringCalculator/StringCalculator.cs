
using StringCalculator.DelimiterSpecifications;

namespace StringCalculator;

public partial class StringCalculator
{
    ExpressionHandler expressionHandler;

    public StringCalculator(ExpressionHandler expressionHandler)
    {
        this.expressionHandler = expressionHandler;
    }

    public int Add(string expression, IDelimiterSpecification delimiterSpecification)
    {
        if (string.IsNullOrEmpty(expression)) return 0;
        expressionHandler.SetExpression(expression);
        var numbers = delimiterSpecification.GetNumbers(expressionHandler);
        return Sum(numbers);
    }

    private int Sum(string[] numbers) 
    {
        var sum = 0;
        foreach (var number in numbers)
        {
            sum += ParseNumber(number);
        }
        return sum;
    }

    private int ParseNumber(string number)
    {
        if (int.TryParse(number, out var intNumber)) return intNumber;

        throw new ArgumentException($"Unexpected Number: {number}");
    }

    public StringCalculator SplitWith(char splitter)
    {
        expressionHandler.IncludeSplitter(splitter);
       return this;
    }
}
