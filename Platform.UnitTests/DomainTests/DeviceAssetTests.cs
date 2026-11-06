using Microsoft.VisualStudio.TestTools.UnitTesting;
using IoTPlatform.Domain.Entities;
using IoTPlatform.Domain.ValueObjects;
using IoTPlatform.Domain.Exceptions;

namespace IoTPlatform.UnitTests.DomainTests;

[TestClass]
public class DeviceAssetTests
{
    private DeviceAsset CreateDevice()
    {
        return new DeviceAsset(
            SerialNumber.Create("IOT-ABC-1234"),
            "Temperature Sensor",
            "Factory A",
            OperatingLimits.Create(1, 100));
    }

    [TestMethod]
    public void NewDevice_HasRegisteredStatus()
    {
        var device = CreateDevice();

        Assert.AreEqual(
            DeviceStatus.Registered,
            device.Status);
    }

    [TestMethod]
    public void ChangeStatus_RegisteredToActive_Success()
    {
        var device = CreateDevice();

        device.ChangeStatus(DeviceStatus.Active);

        Assert.AreEqual(DeviceStatus.Active, device.Status);
    }

    [TestMethod]
    public void ChangeStatus_ActiveToMaintenance_Success()
    {
        var device = CreateDevice();

        device.ChangeStatus(DeviceStatus.Active);
        device.ChangeStatus(DeviceStatus.UnderMaintenance);

        Assert.AreEqual(
            DeviceStatus.UnderMaintenance,
            device.Status);
    }

    [TestMethod]
    public void ChangeStatus_RetiredToActive_ThrowsException()
    {
        var device = CreateDevice();

        device.ChangeStatus(DeviceStatus.Retired);

        Assert.Throws<DomainException>(() =>
            device.ChangeStatus(DeviceStatus.Active));
    }

    [TestMethod]
    public void ChangeStatus_RegisteredToMaintenance_ThrowsException()
    {
        var device = CreateDevice();

        Assert.Throws<DomainException>(() =>
            device.ChangeStatus(DeviceStatus.UnderMaintenance));
    }
}