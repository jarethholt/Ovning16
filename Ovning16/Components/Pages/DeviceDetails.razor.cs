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
    protected bool FinishedSearch { get; set; } = false;
    private Device? _device;
    protected bool FoundDevice { get; set; } = false;

    protected IQueryable<DateTime>? itemsQueryable;
    protected int queryableCount = 0;
    public PaginationState pagination = new() { ItemsPerPage = 10 };

    protected override void OnInitialized()
    {
        _device = DeviceDataService.GetDeviceByGuid(DeviceGuid);
        FinishedSearch = true;
        if (_device is not null)
        {
            FoundDevice = true;
            Device = _device;
            itemsQueryable = Device.ConnectionEvents.AsQueryable().OrderByDescending(dt => dt);
            queryableCount = itemsQueryable.Count();
        }
    }
}
