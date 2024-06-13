using Microsoft.AspNetCore.Components;

namespace Ovning16.Components.Helpers;

public partial class SuccessMessage
{
    [Parameter]
    public required string Message { get; set; }
    [Parameter]
    public bool Saved { get; set; } = false;
    [Parameter]
    public (string, string)[] LinkHrefsAndTexts { get; set; } = [];

    [Parameter]
    public RenderFragment? ChildContent { get; set; }
}
