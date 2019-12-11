using Microsoft.AspNetCore.Components;

namespace Toastr
{
    public partial class Toast
    {
        [Parameter]
        public ToastOptions Options { get; set; }

        [Parameter]
        public EventCallback<ToastOptions> OnRemove { get; set; }

        protected void OnClose()
        {
            OnRemove.InvokeAsync(Options);
        }

        protected void OnTapClose()
        {
            if (Options.TapToDismiss)
            {
                OnRemove.InvokeAsync(Options);
            }
        }

        protected override void OnAfterRender(bool firstRender)
        {

            base.OnAfterRender(firstRender);
            if (firstRender)
            {
                Options.ShowClass = "show";  // turns off fadeIn
            }
            //if (!Options.Display)
            //{
            // //   OnRemove.InvokeAsync(Options);
            //}
        }

        protected string ToastClass
        {
            get
            {
                return string.IsNullOrWhiteSpace(Options.ToastClass) ? string.Empty : Options.ToastClass;
            }
        }

        protected string Icon
        {
            get
            {
                return string.IsNullOrWhiteSpace(Options.IconClass) ? string.Empty : Options.IconClass;
            }
        }

        protected string RTL
        {
            get
            {
                return Options.RTL ? "rtl" : string.Empty;
            }
        }

        protected string Display
        {
            get
            {
                if (Options.Display)
                {
                    return Options.ShowClass;
                }
                else
                {
                    return Options.HideClass;
                }
            }
        }
    }

}
