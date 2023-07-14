namespace Geometry.Models;

/// <summary>
/// Circle class.
/// </summary>
public class Circle : Shape
{
    private readonly double _radius;

    /// <summary>
    /// Circle constructor.
    /// </summary>
    /// <param name="radius"> Circle radius. </param>
    /// <exception cref="ArgumentException"> If radius is incorrect. </exception>
    public Circle(double radius)
    {
        _radius = radius;
        ValidateRadius();
    }

    /// <summary>
    /// Circle square.
    /// </summary>
    public override double Square => Math.PI * Math.Pow(_radius, 2);

    /// <summary>
    /// Check circle radius.
    /// </summary>
    /// <exception cref="ArgumentException"> If the radius is invalid. </exception>
    private void ValidateRadius()
    {
        if (!double.IsFinite(_radius) || _radius <= 0)
        {
            throw new ArgumentException("Radius must be positive number.");
        }

        if (_radius < _minRadius)
        {
            throw new ArgumentException("Radius is too small.");
        }

        if (_radius > _maxRadius)
        {
            throw new ArgumentException("Radius is too big.");
        }
    }

    private static readonly double _minRadius = Math.Sqrt(double.Epsilon);
    private static readonly double _maxRadius = Math.Sqrt(double.MaxValue / Math.PI);
}