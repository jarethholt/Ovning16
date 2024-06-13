using Microsoft.AspNetCore.Components;
using Ovning16.Contracts.Services;
using Ovning16.Models;
using Microsoft.AspNetCore.Components.QuickGrid;

namespace Ovning16.Components.Pages;

public partial class DeviceDetails
{
    [Inject]
    public IDeviceDataService DeviceDataService { get; set; } = null!;

    [Parameter]
    public Guid DeviceGuid { get; set; }

    public Device Device { get; set; } = new();

    protected IQueryable<DateTime>? itemsQueryable;
    protected int queryableCount = 0;
    public PaginationState pagination = new() { ItemsPerPage = 10 };

    protected void SetDevice(Device device)
    {
        Device = device;
        itemsQueryable = Device.ConnectionEvents.AsQueryable().OrderByDescending(dt => dt);
        queryableCount = itemsQueryable.Count();
    }
}
