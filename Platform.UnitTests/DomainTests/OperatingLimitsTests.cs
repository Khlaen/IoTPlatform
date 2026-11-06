using Microsoft.VisualStudio.TestTools.UnitTesting;
using IoTPlatform.Domain.ValueObjects;
using IoTPlatform.Domain.Exceptions;

namespace IoTPlatform.UnitTests.DomainTests;

[TestClass]
public class OperatingLimitsTests
{
    [TestMethod]
    public void Create_ValidLimits_Success()
    {
        var limits = OperatingLimits.Create(10, 100);

        Assert.AreEqual(10, limits.Minimum);
        Assert.AreEqual(100, limits.Maximum);
    }

    [TestMethod]
    public void Create_NegativeMinimum_ThrowsException()
    {
        Assert.Throws<DomainException>(() =>
            OperatingLimits.Create(-5, 100));
    }

    [TestMethod]
    public void Create_ZeroMaximum_ThrowsException()
    {
        Assert.Throws<DomainException>(() =>
            OperatingLimits.Create(5, 0));
    }

    [TestMethod]
    public void Create_MaximumLessThanMinimum_ThrowsException()
    {
        Assert.Throws<DomainException>(() =>
            OperatingLimits.Create(100, 50));
    }

    [TestMethod]
    public void Contains_ValueWithinRange_ReturnsTrue()
    {
        var limits = OperatingLimits.Create(10, 100);

        Assert.IsTrue(limits.Contains(50));
    }

    [TestMethod]
    public void Contains_ValueOutsideRange_ReturnsFalse()
    {
        var limits = OperatingLimits.Create(10, 100);

        Assert.IsFalse(limits.Contains(150));
    }
}
