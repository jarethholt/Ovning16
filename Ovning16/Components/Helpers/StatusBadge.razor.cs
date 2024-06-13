using Microsoft.AspNetCore.Components;

namespace Ovning16.Components.Helpers;

public partial class StatusBadge
{
    [Parameter]
    public bool Status { get; set; }
}
