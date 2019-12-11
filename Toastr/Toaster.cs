using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

namespace Toastr
{
    public partial class Toaster : IDisposable
    {
       
        private bool disposed = false;

        protected override void OnInitialized()
        {
            ToastService.OnAddToast += AddToast;
            ToastService.OnRemoveToast += RemoveToast;
            ToastService.OnRemoveFirstToast += RemoveFirstToast;
            ToastService.OnRemoveLastToast += RemoveLastToast;
            ToastService.OnRemoveAllToast += Clear;
        }

        [Inject]
        IToastService ToastService { get; set; }

        [Parameter]
        public string ContainerId { get; set; } = "toast-container";

        [Parameter]
        public string PositionClass { get; set; } = "toast-top-right";

        [Parameter]
        public bool NewestOnTop { get; set; } = false;

        [Parameter]
        public bool PreventDuplicates { get; set; } = false;

        private List<ToastOptions> Options { get; set; } = new List<ToastOptions>();

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1303:Do not pass literals as localized parameters", Justification = "<Pending>")]
        public void AddToast(ToastOptions options, string title, string message)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options), "The ToastOptions object cannot be null.");
            }
            options.Display = true;
            options.Title = title ?? string.Empty;
            options.Message = message ?? string.Empty;
            if (PreventDuplicates)
            {
                foreach (var option in Options)
                {
                    if (options.Equals(option))
                    {
                        return;
                    }
                }
            }
            if (NewestOnTop)
            {
                Options.Insert(0, options);
            }
            else
            {
                Options.Add(options);
            }
            StateHasChanged();
        }

        public void Clear()
        {
            Options.Clear();
            StateHasChanged();
        }

        public void RemoveToast(ToastOptions options)
        {
            if (options != null)
            {
                InvokeAsync(() =>
                {
                    // change the CSS to fadeOut, slideDown or hide here, call StateHasChanged.  Use timer, can set ease duration in Toast.cs
                    Options.Remove(options);
                    StateHasChanged();
                });
            }
        }

        public void RemoveFirstToast()
        {
            if (Options.Count > 0)
            {
                RemoveToast(Options[0]);
            }
        }

        public void RemoveLastToast()
        {
            if (Options.Count > 0)
            {
                RemoveToast(Options[Options.Count - 1]);
            }
        }

        public static ToastOptions CreateToastOptions(ToastOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }
            return new ToastOptions(options);
        }

        #region IDisposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                ToastService.OnAddToast -= AddToast;
                ToastService.OnRemoveToast -= RemoveToast;
                ToastService.OnRemoveFirstToast -= RemoveFirstToast;
                ToastService.OnRemoveLastToast -= RemoveLastToast;
                ToastService.OnRemoveAllToast -= Clear;
            }
            disposed = true;
        }
        #endregion IDisposable

    }
}
