using Microsoft.VisualStudio.TestTools.UnitTesting;
using IoTPlatform.Domain.Entities;
using IoTPlatform.Domain.Exceptions;

namespace IoTPlatform.UnitTests.DomainTests;

[TestClass]
public class AlertRuleTests
{
    [TestMethod]
    public void ShouldTrigger_ValueAboveThreshold_ReturnsTrue()
    {
        var rule = new AlertRule(1, "Temperature", 80, true);

        Assert.IsTrue(rule.ShouldTrigger(90));
    }

    [TestMethod]
    public void ShouldTrigger_ValueBelowThreshold_ReturnsTrue()
    {
        var rule = new AlertRule(1, "Temperature", 80, false);

        Assert.IsTrue(rule.ShouldTrigger(70));
    }

    [TestMethod]
    public void ShouldTrigger_AlertDisabled_ReturnsFalse()
    {
        var rule = new AlertRule(1, "Temperature", 80, true);

        rule.Disable();

        Assert.IsFalse(rule.ShouldTrigger(90));
    }

    [TestMethod]
    public void Create_ZeroThreshold_ThrowsException()
    {
        Assert.Throws<DomainException>(() =>
            new AlertRule(1, "Temperature", 0, true));
    }
}
