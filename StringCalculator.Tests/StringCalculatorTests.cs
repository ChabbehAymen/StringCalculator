
namespace StringCalculator.Tests;

using FluentAssertions;
using NSubstitute;

public class StringCalculatorTests
{
    StringCalculator sut;
    INumbersPreparer numbersPreparer;
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
        var actual = sut.Add(input, [',']);
        
        actual.Should().Be(expected);
    }
    [Fact]
    public void ShouldCalculateSumOfNumbersSplattedByNewLine()
    {
        const string Input = "1\n2,3";
        const int Expected = 6;

        var actual = sut.Add(Input, [',', '\n']);

        actual.Should().Be(Expected);
    }
    
    [Fact]
    public void ShouldCalculateSumOfNumbersSplattedByProvidedDelimiter()
    {
        const string Input = "//;\n1;2";
        const int Expected = 3;

        var actual = sut.Add(Input);

        actual.Should().Be(Expected);
    }

    [Fact]
    public void ShouldNotAcceptNegativeNumbers()
    {
        const string Input = "//;\n-1;2";

        var act = () => sut.Add(Input);

        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void ShouldReturnAddInvocationCount()
    {
        const string Input = "//;\n1;2";
        const int Expected = 3;
        sut.Add(Input);
        sut.Add(Input);
        sut.Add(Input);

        var actual = sut.GetAddCallCount();

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
        sut.Add(Input);

        invoked.Should().BeTrue();
    }

    [Fact]
    public void ShouldIgnoreNumbersBiggerThenOneThousand()
    {
        const string Input = "//;\n10002;2";
        const int Expected = 2;

        var actual = sut.Add(Input);

        actual.Should().Be(Expected);
    }

    [Fact]
    public void ShouldExceptDelimiterOfAnyLength()
    {
        const string Input = "//[fa]\n2fa2";
        const int Expected = 4;

        var actual = sut.Add(Input);

        actual.Should().Be(Expected);
    }
    
    [Fact]
    public void ShouldExceptMultiDelimiters()
    {
        const string Input = "//[*][%]\\n1*2%3";
        const int Expected = 6;
        
        var actual = sut.Add(Input);

        actual.Should().Be(Expected);
    }
}
