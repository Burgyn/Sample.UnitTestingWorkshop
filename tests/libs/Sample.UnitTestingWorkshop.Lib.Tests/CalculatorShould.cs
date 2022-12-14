using FluentAssertions;
using Samples.UnitTestingWorkshop.Lib;

namespace Sample.UnitTestingWorkshop.Lib.Tests;

public class CalculatorShould
{
    [Theory]
    [InlineData(5, 5, 10)]
    public void AddTwoNumbers(int a, int b, int expected)
    {
        var sut = new Calculator();

        var actual = sut.Add(a, b);

        expected.Should().Be(actual);
    }

    [Theory]
    [InlineData(5, 5, 0)]
    public void SubtractTwoNumbers(int a, int b, int expected)
    {
        var sut = new Calculator();

        var actual = sut.Subtract(a, b);

        expected.Should().Be(actual);
    }

    [Theory]
    [InlineData(1, 1, 1)]
    public void MultiplyTwoNumbers(int a, int b, int expected)
    {
        var sut = new Calculator();

        var actual = sut.Multiply(a, b);

        expected.Should().Be(actual);
    }

    [Theory]
    [InlineData(1, 1, 1,0)]
    public void DivideTwoNumbers(int a, int b, int expected, int remainder)
    {
        var sut = new Calculator();

        var actual = sut.Divide(a, b);

        expected.Should().Be(actual.Result);
        remainder.Should().Be(actual.Remainder);
    }

    [Fact]
    public void ThrowDivideByZeroException()
    {
        var sut = new Calculator();

        Action act = () => sut.Divide(5, 0);

        act.Should().Throw<DivideByZeroException>();
    }
}