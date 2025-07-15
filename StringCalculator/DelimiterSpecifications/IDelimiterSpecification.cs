namespace StringCalculator.DelimiterSpecifications;

public interface IDelimiterSpecification
{
    public string[] GetNumbers(ExpressionHandler expression);
}
