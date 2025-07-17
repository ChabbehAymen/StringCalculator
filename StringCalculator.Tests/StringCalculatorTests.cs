using FluentAssertions;

namespace StringCalculator.Tests;

public class StringCalculatorTests
{
    StringCalculator sut;
    public StringCalculatorTests()
    {
        sut = CompositionRoot.ComposeProgram();
    }

    [Theory]
    [InlineData("", 0)]
    [InlineData("1", 1)]
    [InlineData("1,2", 3)]
    public void ShouldCalculateSumOfNumbersSplattedByComa(string input, int expected)
    {
        sut.SplitWith(',');

        var actual = sut.Add(input, DelimiterSpecificationFactory.NoDelimiter);
        
        actual.Should().Be(expected);
    }

    [Fact]
    public void ShouldCalculateSumOfNumbersSplattedByNewLine()
    {
        const string Input = "1\n2,3";
        const int Expected = 6;
        sut.SplitWith(',').SplitWith('\n');

        var actual = sut.Add(Input, DelimiterSpecificationFactory.NoDelimiter);

        actual.Should().Be(Expected);
    }

    [Fact]
    public void ShouldCalculateSumOfNumbersSplattedByProvidedDelimiter()
    {
        const string Input = "//;\n1;2";
        const int Expected = 3;
        
        var actual = sut.Add(Input, DelimiterSpecificationFactory.SingleDelimiterExpression);

        actual.Should().Be(Expected);
    }

    [Fact]
    public void ShouldNotAcceptNegativeNumbers() 
    {
        const string Input = "//;\n-1;2";

        var act = () => sut.Add(Input, DelimiterSpecificationFactory.SingleDelimiterExpression);

        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void ShouldReturnAddInvocationCount() 
    {
        const string Input = "//;\n1;2";
        const int Expected = 3;
        sut.Add(Input, DelimiterSpecificationFactory.SingleDelimiterExpression);
        sut.Add(Input, DelimiterSpecificationFactory.SingleDelimiterExpression);
        sut.Add(Input, DelimiterSpecificationFactory.SingleDelimiterExpression);

        var actual = sut.GetCalledCount();

        actual.Should().Be(Expected);
    }

    [Fact]
    public void ShouldInvokeAddOccurredEvent()
    {
        const string Input = "//;\n1;2";
        var invoked = false;

        sut.AddOccurred += (message, number) =>
        {
            invoked = true;
            number++;
        };
        sut.Add(Input, DelimiterSpecificationFactory.SingleDelimiterExpression);
        
        invoked.Should().BeTrue();
    }

    [Fact]
    public void ShouldIgnoreNumbersBiggerThenOneThousand() 
    {
        const string Input = "//;\n10002;2";
        const int Expected = 2;

        var actual = sut.Add(Input, DelimiterSpecificationFactory.SingleDelimiterExpression);

        actual.Should().Be(Expected);
    }

    [Fact]
    public void ShouldExceptDelimiterOfAnyLength()
    {
        const string Input = "//[fa]\n2fa2";
        const int Expected = 4;

        var actual = sut.Add(Input, DelimiterSpecificationFactory.LargeDelimiterExpression);

        actual.Should().Be(Expected);
    }
}
