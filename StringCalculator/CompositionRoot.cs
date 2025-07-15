
namespace StringCalculator;

public class CompositionRoot
{
    public static StringCalculator ComposeProgram() 
    {
        var delimiterHandler = new DelimiterHandler();
        var numbersHandler = new NumbersHandler();
        var expressionHandler = new ExpressionHandler(delimiterHandler, numbersHandler);
        var stringCalculator = new StringCalculator(expressionHandler);
        return stringCalculator;
    }
}
