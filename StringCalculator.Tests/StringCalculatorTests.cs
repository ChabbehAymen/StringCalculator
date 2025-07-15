using FluentAssertions;
using NSubstitute;
using StringCalculator.DelimiterSpecifications;

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

        var actual = sut.Add(input, StringCalculatorOptions.NoDelimiter);
        
        actual.Should().Be(expected);
    }

    [Fact]
    public void ShouldCalculateSumOfNumbersSplattedByNewLine()
    {
        const string Input = "1\n2,3";
        const int Expected = 6;
        sut.SplitWith(',').SplitWith('\n');

        var actual = sut.Add(Input, StringCalculatorOptions.NoDelimiter);

        actual.Should().Be(Expected);
    }

    [Fact]
    public void ShouldCalculateSumOfNumbersSplattedByProvidedDelimiter()
    {
        const string Input = "//;\n1;2";
        const int Expected = 3;
        
        var actual = sut.Add(Input, StringCalculatorOptions.SingleDelimiterExpression);

        actual.Should().Be(Expected);
    }
}
