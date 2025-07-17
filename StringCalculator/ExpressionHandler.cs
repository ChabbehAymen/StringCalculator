

namespace StringCalculator;


public class ExpressionHandler
{
    DelimiterHandler delimiterHandler;
    NumbersHandler numbersHandler;
    string expression = "";

    public ExpressionHandler(DelimiterHandler delimiterHandler, NumbersHandler numbersHandler)
    {
        this.delimiterHandler = delimiterHandler;
        this.numbersHandler = numbersHandler;
    }
    public int[] WithSplitters()
    {
        numbersHandler.SetNumbers(expression);
        numbersHandler.SplitNumbers(delimiterHandler.GetDelimiters());
        return numbersHandler.ParseNumbers();
    }

    // TODO Refactor
    public int[] WithSingleDelimiter()
    {
        delimiterHandler.ExtractSingleDelimiter(expression);
        numbersHandler.SetNumbers(expression, true);
        numbersHandler.SplitNumbers(delimiterHandler.GetDelimiters());
        return numbersHandler.ParseNumbers();
    }

    // TODO Refactor
    public int[] WithLargeDelimiter()
    {
        delimiterHandler.ExtractLargeDelimiter(expression);
        numbersHandler.SetNumbers(expression, true);
        numbersHandler.SplitNumbers(delimiterHandler.GetDelimiters());
        return numbersHandler.ParseNumbers();

    }

    public void SetExpression(string expression)
    {
        this.expression = expression;
    }

    public void IncludeSplitter(char splitter)
    {
        delimiterHandler.Include(splitter);
    }
}