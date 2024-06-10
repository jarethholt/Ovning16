using Ovning16.Models;

namespace Ovning16.Contracts.Services;

public interface IDeviceDataService
{
    public IEnumerable<Device> GetDevices();
    public Device? GetDeviceById(int id);
    public Device? GetDeviceByGuid(Guid guid);
    public Device? GetDeviceByGuid(string guidString);
    public Device AddDevice(Device device);
    public Device? UpdateDevice(Device device);
    public void DeleteDevice(Device device);
}
