namespace Geometry.Models;

/// <summary>
/// Triangle class.
/// </summary>
public class Triangle : Shape
{
    private readonly double _firstSide;
    private readonly double _secondSide;
    private readonly double _thirdSide;

    /// <summary>
    /// Triangle constructor.
    /// </summary>
    /// <param name="firstSide"> Triangle first side. </param>
    /// <param name="secondSide"> Triangle second side. </param>
    /// <param name="thirdSide"> Triangle third side. </param>
    public Triangle(double firstSide, double secondSide, double thirdSide)
    {
        _firstSide = firstSide;
        _secondSide = secondSide;
        _thirdSide = thirdSide;
        ValidateSides();
    }


    /// <summary>
    /// Triangle square.
    /// </summary>
    public override double Square
    {
        get
        {
            var halfPerimeter = (_firstSide + _secondSide + _thirdSide) / 2;

            return Math.Sqrt(
                halfPerimeter * (halfPerimeter - _firstSide) * (halfPerimeter - _secondSide) * (halfPerimeter - _thirdSide)
            );
        }
    }

    /// <summary>
    /// Check triangle sides.
    /// </summary>
    /// <exception cref="ArgumentException"> If one if the sides is invalid. </exception>
    private void ValidateSides()
    {
        ValidateSide(_firstSide);
        ValidateSide(_secondSide);
        ValidateSide(_thirdSide);

        if (_firstSide + _secondSide <= _thirdSide
            || _firstSide + _thirdSide <= _secondSide
            || _secondSide + _thirdSide <= _firstSide)
        {
            throw new ArgumentException("Incorrect triangle sides proportion.");
        }

        if (Square == double.PositiveInfinity)
        {
            throw new ArgumentException("One of the sides is too big.");
        }
    }

    private static void ValidateSide(double side)
    {
        if (!double.IsFinite(side) || side <= 0)
        {
            throw new ArgumentException("Side must be positive number.");
        }
    }

    /// <summary>
    /// Is triangle right.
    /// </summary>
    public bool IsRight
    {
        get
        {
            if (IsTriangleRight(_firstSide, _secondSide, _thirdSide)
                || IsTriangleRight(_firstSide, _thirdSide, _secondSide)
                || IsTriangleRight(_secondSide, _thirdSide, _firstSide))
            {
                return true;
            }

            return false;
        }
    }

    private static bool IsTriangleRight(
        double firstCathetus,
        double secondCathetus,
        double hypotenuse)
    {
        return Math.Abs(
                Math.Pow(firstCathetus, 2)
                + Math.Pow(secondCathetus,2)
                - Math.Pow(hypotenuse, 2)
            ) < Constants.MarginOfError;
    }
}
