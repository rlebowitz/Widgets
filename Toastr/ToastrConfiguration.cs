using System;
using System.Collections.Generic;
using System.Text;

namespace Toastr
{
    //https://weblog.west-wind.com/posts/2017/dec/12/easy-configuration-binding-in-aspnet-core-revisited
    //https://codereview.stackexchange.com/questions/185297/adding-extension-methods-to-iservicecollection-in-asp-net-core

    public class ToastrConfiguration
    {
        public string ContainerId { get; set; } = "toast-container";

        public string PositionClass { get; set; } = "toast-top-right";

        public bool NewestOnTop { get; set; } = true;

        public bool PreventDuplicates { get; set; } = false;

        public ToastOptions ToastOptions { get; set; } = new ToastOptions();

    }
}
