using System;

namespace Sakura.AspNetCore.Mvc.Implementations;

public record Bootstrap5ToastMessageHtmlGeneratorOptions
{
    public bool Dismissible { get; set; } = true;
    public bool ShowIcon { get; set; } = true;

    public string DismissAriaLabel { get; set; } = "Close";

    public bool Animation { get; set; } = true;
    public bool AutoHide { get; set; } = true;

    public TimeSpan Delay { get; set; } = TimeSpan.FromSeconds(5);

    public HorizontalAlignment HorizontalAlignment { get; set; } = HorizontalAlignment.Right;
    public VerticalAlignment VerticalAlignment { get; set; } = VerticalAlignment.Bottom;
}