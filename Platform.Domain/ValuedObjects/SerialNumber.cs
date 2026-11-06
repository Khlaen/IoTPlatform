using System.Text.RegularExpressions;
using IoTPlatform.Domain.Exceptions;

namespace IoTPlatform.Domain.ValueObjects;

public sealed class SerialNumber
{
    public string Value { get; private set; }

    private SerialNumber(string value)
    {
        Value = value;
    }

    public static SerialNumber Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value) ||
            !Regex.IsMatch(value, @"^IOT-[A-Z]{3}-[0-9]{4}$"))
        {
            throw new DomainException(
                "Serial number must follow IOT-ABC-1234 format.");
        }

        return new SerialNumber(value);
    }

    public override string ToString() => Value;
}
