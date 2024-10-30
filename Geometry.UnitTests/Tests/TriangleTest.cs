using FluentAssertions;
using Geometry.Models;
using static System.Net.WebRequestMethods;

namespace Geometry.UnitTests.Tests;

public class TriangleTest
{
    [Theory]
    [InlineData(-1, 1, 1)]
    [InlineData(1, -1, 1)]
    [InlineData(1, 1, -1)]
    [InlineData(-1, -1, 1)]
    [InlineData(-1, 1, -1)]
    [InlineData(1, -1, -1)]
    [InlineData(-1, -1, -1)]
    [InlineData(0, 1, 1)]
    [InlineData(1, 0, 1)]
    [InlineData(1, 1, 0)]
    [InlineData(0, 0, 1)]
    [InlineData(0, 1, 0)]
    [InlineData(1, 0, 0)]
    [InlineData(0, 0, 0)]
    public void CreateTriangle_NonPositiveSide_ThrowsArgumentException(
        double firstSide,
        double secondSide,
        double thirdSide)
    {
        Action act = () => CreateTriangle(firstSide, secondSide, thirdSide);

        act
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Side must be positive number.");
    }

    [Theory]
    [InlineData(double.MaxValue / 2, double.MaxValue / 2, double.MaxValue / 2)]
    [InlineData(1e+300, 1e+300, 1e+300)]
    public void CreateTriangle_TooBigSide_ThrowsArgumentException(
        double firstSide,
        double secondSide,
        double thirdSide)
    {
        Action act = () => CreateTriangle(firstSide, secondSide, thirdSide);

        act
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("One of the sides is too big.");
    }

    [Theory]
    [InlineData(1, 1, 2.1)]
    [InlineData(5, 2, 2)]
    [InlineData(1, 24.3, 3)]
    public void CreateTriangle_InvalidProportion_ThrowsArgumentException(
        double firstSide,
        double secondSide,
        double thirdSide)
    {
        Action act = () => CreateTriangle(firstSide, secondSide, thirdSide);

        act
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Incorrect triangle sides proportion.");
    }

    [Theory]
    [InlineData(1, 1, 1)]
    [InlineData(3, 4, 5)]
    [InlineData(6.3, 4.2, 7.1)]
    public void CreateTriangle_CorrectSides_Success(
        double firstSide,
        double secondSide,
        double thirdSide)
    {
        Action act = () => CreateTriangle(firstSide, secondSide, thirdSide);

        act
            .Should()
            .NotThrow();
    }

    [Theory]
    [InlineData(3, 4, 5)]
    [InlineData(5, 12, 13)]
    public void IsRight_CorrectTriangle_ReturnsTrue(
        double firstSide,
        double secondSide,
        double thirdSide)
    {
        var triangle = CreateTriangle(firstSide, secondSide, thirdSide);

        triangle.IsRight
            .Should()
            .BeTrue();
    }

    [Theory]
    [InlineData(1, 1.8, 1)]
    [InlineData(3.3, 4, 5)]
    [InlineData(5.5, 5.5, 5.5)]
    public void IsRight_IncorrectTriangle_ReturnsFalse(
        double firstSide,
        double secondSide,
        double thirdSide)
    {
        var triangle = CreateTriangle(firstSide, secondSide, thirdSide);

        triangle.IsRight
            .Should()
            .BeFalse();
    }

    [Theory]
    [InlineData(3, 4, 5, 6)]
    [InlineData(1, 1, 1, 0.4330127019)]
    [InlineData(258.6, 159.3, 201.18, 16021.9416252523)]
    public void Square_CorrectSides_ReturnsSquare(
        double firstSide,
        double secondSide,
        double thirdSide,
        double expectedSquare)
    {
        var triangle = CreateTriangle(firstSide, secondSide, thirdSide);

        triangle.Square
            .Should()
            .BeApproximately(expectedSquare, Constants.MarginOfError);
    }

    private static Triangle CreateTriangle(
        double firstSide,
        double secondSide,
        double thirdSide)
    {
        return new Triangle(firstSide, secondSide, thirdSide);
    }
}
