

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
    public string[] WithSplitters()
    {
        numbersHandler.SetNumbers(expression);
        return numbersHandler.SplitNumbers(delimiterHandler.GetDelimiters());
    }
    public string[] WithSingleDelimiter()
    {
        delimiterHandler.SetDelimiterFromExpression(expression);
        numbersHandler.ExtractNumbers(expression);
        return numbersHandler.SplitNumbers(delimiterHandler.GetDelimiters());
    }

    public void SetExpression(string expression)
    {
        this.expression = expression;
    }

    internal void IncludeSplitter(char splitter)
    {
        delimiterHandler.Include(splitter);
    }
}