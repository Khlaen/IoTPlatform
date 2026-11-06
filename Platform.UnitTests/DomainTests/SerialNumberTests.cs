using Microsoft.VisualStudio.TestTools.UnitTesting;
using IoTPlatform.Domain.ValueObjects;
using IoTPlatform.Domain.Exceptions;

namespace IoTPlatform.UnitTests.DomainTests;

[TestClass]
public class SerialNumberTests
{
    [TestMethod]
    public void Create_ValidSerialNumber_Success()
    {
        var result = SerialNumber.Create("IOT-ABC-1234");

        Assert.AreEqual("IOT-ABC-1234", result.Value);
    }

    [TestMethod]
    public void Create_InvalidSerialNumber_ThrowsException()
    {
        Assert.Throws<DomainException>(() =>
            SerialNumber.Create("12345"));
    }

    [TestMethod]
    public void Create_LowercaseSerialNumber_ThrowsException()
    {
        Assert.Throws<DomainException>(() =>
            SerialNumber.Create("iot-abc-1234"));
    }
}
