using IoTPlatform.Domain.Exceptions;

namespace IoTPlatform.Domain.ValueObjects;

public sealed class OperatingLimits
{
    public decimal Minimum { get; private set; }

    public decimal Maximum { get; private set; }

    private OperatingLimits(decimal minimum, decimal maximum)
    {
        Minimum = minimum;
        Maximum = maximum;
    }

    public static OperatingLimits Create(
        decimal minimum,
        decimal maximum)
    {
        if (minimum <= 0)
            throw new DomainException(
                "Minimum limit must be positive.");

        if (maximum <= 0)
            throw new DomainException(
                "Maximum limit must be positive.");

        if (maximum <= minimum)
            throw new DomainException(
                "Maximum must be greater than minimum.");

        return new OperatingLimits(minimum, maximum);
    }

    public bool Contains(decimal value)
    {
        return value >= Minimum && value <= Maximum;
    }
}
