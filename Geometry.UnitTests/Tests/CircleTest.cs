using FluentAssertions;
using Geometry.Models;

namespace Geometry.UnitTests.Tests;

public class CircleTest
{
    [Theory]
    [InlineData(double.NegativeInfinity)]
    [InlineData(double.PositiveInfinity)]
    [InlineData(double.NaN)]
    [InlineData(-1)]
    [InlineData(0)]
    public void Constructor_NonPositiveRadius_ThrowsArgumentException(double radius)
    {
        Action act = () => CreateCircle(radius);

        act
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Radius must be positive number.");
    }

    [Theory]
    [InlineData(double.Epsilon)]
    public void Constructor_TooSmallRadius_ThrowsArgumentException(double radius)
    {
        Action act = () => CreateCircle(radius);

        act
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Radius is too small.");
    }

    [Theory]
    [InlineData(double.MaxValue)]
    [InlineData(1e+160)]
    public void Constructor_TooBigRadius_ThrowsArgumentException(double radius)
    {
        Action act = () => CreateCircle(radius);

        act
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Radius is too big.");
    }

    [Theory]
    [InlineData(100)]
    [InlineData(1e+150)]
    public void Constructor_CorrectRadius_Success(double radius)
    {
        Action act = () => CreateCircle(radius);

        act
            .Should()
            .NotThrow();
    }

    [Theory]
    [InlineData(1, Math.PI)]
    [InlineData(4, 16 * Math.PI)]
    [InlineData(1e-15, 3.14159265e-20)]
    public void GetSquare_CorrectRadius_ReturnsCorrectSquare(double radius, double expectedSquare)
    {
        var circle = CreateCircle(radius);

        circle.Square
            .Should()
            .BeApproximately(expectedSquare, Constants.MarginOfError);
    }

    private Circle CreateCircle(double radius)
    {
        return new Circle(radius);
    }
}
