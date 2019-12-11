using System;

namespace Toastr
{
    public interface IToastService
    {
        event Action<ToastOptions, string, string> OnAddToast;
        event Action OnRemoveAllToast;
        event Action OnRemoveFirstToast;
        event Action OnRemoveLastToast;
        event Action<ToastOptions> OnRemoveToast;

        void AddErrorToast(string title, string message);
        void AddInfoToast(string title, string message);
        void AddSuccessToast(string title, string message);
        void AddToast(ToastOptions options, string title, string message);
        void AddWarningToast(string title, string message);
        ToastOptions CreateToast();
        void Dispose();
        void RemoveAllToast();
        void RemoveFirstToast();
        void RemoveLastToast();
    }
}