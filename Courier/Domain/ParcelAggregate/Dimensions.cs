using Courier.Domain.SeedWork;

namespace Courier.Domain.ParcelAggregate;

public class Dimensions : ValueObject
{
    public decimal Length { get; }
    public decimal Width { get; }
    public decimal Height { get; }

    // EF Core needs this parameterless constructor
    public Dimensions() { }
    
    public Dimensions(decimal length, decimal width, decimal height)
    {
        if (length <= 0) throw new ArgumentOutOfRangeException(nameof(length));
        if (width <= 0) throw new ArgumentOutOfRangeException(nameof(width));
        if (height <= 0) throw new ArgumentOutOfRangeException(nameof(height));

        Length = length;
        Width = width;
        Height = height;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Length;
        yield return Width;
        yield return Height;
    }
}