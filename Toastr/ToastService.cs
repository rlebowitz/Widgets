using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Timers;

namespace Toastr
{
    public class ToastService : IDisposable, IToastService
    {
        public event Action<ToastOptions, string, string> OnAddToast;
        public event Action<ToastOptions> OnRemoveToast;
        public event Action OnRemoveFirstToast;
        public event Action OnRemoveLastToast;
        public event Action OnRemoveAllToast;
        private Timer Countdown;
        private Stack<ToastOptions> Stack { get; set; } = new Stack<ToastOptions>();
        private readonly ToastrConfiguration Configuration;
        private bool disposed = false;

        public ToastService(IOptions<ToastrConfiguration> config)
        {
            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }
            Configuration = config.Value;
        }

        public void AddErrorToast(string title, string message)
        {
            var options = new ToastOptions(Configuration.ToastOptions)
            {
                IconClass = "toast-error"
            };
            AddToast(options, title, message);
        }

        public void AddInfoToast(string title, string message)
        {
            var options = new ToastOptions(Configuration.ToastOptions)
            {
                IconClass = "toast-info"
            };
            AddToast(options, title, message);
        }

        public void AddWarningToast(string title, string message)
        {
            var options = new ToastOptions(Configuration.ToastOptions)
            {
                IconClass = "toast-warning"
            };
            AddToast(options, title, message);
        }

        public void AddSuccessToast(string title, string message)
        {
            var options = new ToastOptions(Configuration.ToastOptions)
            {
                IconClass = "toast-success"
            };
            AddToast(options, title, message);
        }

        public void AddToast(ToastOptions options, string title, string message)
        {
            OnAddToast?.Invoke(options, title, message);
            if (options.TimeOut > 0)
            {
                StartCountdown(options);
            }
        }

        public void RemoveAllToast()
        {
            OnRemoveAllToast?.Invoke();
        }

        public void RemoveLastToast()
        {
            OnRemoveLastToast?.Invoke();
        }

        public void RemoveFirstToast()
        {
            OnRemoveFirstToast?.Invoke();
        }

        public ToastOptions CreateToast()
        {
            return Toaster.CreateToastOptions(Configuration.ToastOptions);
        }

        private void StartCountdown(ToastOptions options)
        {
            SetCountdown(options);
            Stack.Push(options);
            if (Countdown.Enabled)
            {
                Countdown.Stop();
                Countdown.Start();
            }
            else
            {
                Countdown.Start();
            }
        }

        private void SetCountdown(ToastOptions options)
        {
            if (Countdown == null)
            {
                Countdown = new Timer(options.TimeOut);
                Countdown.Elapsed += RemoveToast;
                Countdown.AutoReset = false;
            }
        }

        private void RemoveToast(object sender, ElapsedEventArgs e)
        {
            while (Stack.Count > 0)
            {
                OnRemoveToast?.Invoke(Stack.Pop());
            }
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
                Stack.Clear();
                Countdown?.Dispose();
            }

            disposed = true;
        }
        #endregion IDisposable
    }
}
