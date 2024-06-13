using Ovning16.Models;

namespace Ovning16.Contracts.Services;

public interface IDeviceDataService
{
    public IEnumerable<Device> GetDevices();
    public Device? GetDeviceByGuid(Guid guid);
    public Device? GetDeviceByGuid(string guidString);
    public Device AddDevice(DeviceAddDTO deviceDTO);
    public Device UpdateDevice(Device device, DeviceUpdateDTO deviceDTO);
    public void DeleteDevice(Device device);
    public (int, int) NumberOfDevicesOnlineAndOffline();
}
