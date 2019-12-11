using System;

namespace Toastr
{
    public class ToastOptions
    {
        private static StringComparison invariant = StringComparison.InvariantCultureIgnoreCase;

        internal ToastOptions()
        {
        }

        internal ToastOptions(ToastOptions options)
        {
            this.CloseButton = options.CloseButton;
            this.CloseButtonClass = options.CloseButtonClass;
            this.Display = options.Display;
            this.FirstRendering = options.FirstRendering;
            this.HideClass = options.HideClass;
            this.IconClass = options.IconClass;
            this.Message = options.Message;
            this.MessageClass = options.MessageClass;
            this.RTL = options.RTL;
            this.ShowClass = options.ShowClass;
            this.TapToDismiss = options.TapToDismiss;
            this.TimeOut = options.TimeOut;
            this.Title = options.Title;
            this.TitleClass = options.TitleClass;
            this.ToastClass = options.ToastClass;
//            this.Type = options.Type;
        }

        /// <summary>
        /// Property that determines which type of toast (info, error, success, warning, or other) this toast is.
        /// </summary>
 //       public string Type { get; set; } = "toast-info";
        /// <summary>
        /// The title string that will be display at the top of the toast.
        /// </summary>
        public string Title { get; set; } = string.Empty;
        /// <summary>
        /// The message string that will be displayed in the body of the toast.
        /// </summary>
        public string Message { get; set; } = string.Empty;
        /// <summary>
        /// Allows user to click or "tap" on the body of the toast to close it, in additionto or as opposed to using the close button.
        /// </summary>
        public bool TapToDismiss { get; set; } = true;
        /// <summary>
        /// Property that determines how long before the toast is automatically removed.
        /// </summary>
        /// <remarks>
        /// The value is expressed in milliseconds.  Use zero (0) to make removal of toasts a manual process.
        /// </remarks>
        public int TimeOut { get; set; } = 0;
        /// <summary>
        /// Determines whether to display a small X button in the upper righthand corner of the toast to close it manually.
        /// </summary>
        public bool CloseButton { get; set; } = false;
        /// <summary>
        /// Apply alternate CSS to accomodate use of Right-To-Left text, usually in Hebrew, Arabic or Persian.
        /// </summary>
        public bool RTL { get; set; } = false;

        public bool FirstRendering { get; set; } = false;
        public bool Display { get; set; } = true;

        #region CSS classes
        public string ToastClass { get; set; } = "toast";
        public string IconClass { get; set; } = "toast-info";
        public string CloseButtonClass { get; set; } = "toast-close-button";
        public string TitleClass { get; set; } = "toast-title";
        public string MessageClass { get; set; } = "toast-message";
        public string ShowClass { get; set; } = "slideDown";
        public string HideClass { get; set; } = "fadeOut";

        #endregion CSS classes

        public string Aria
        {
            get
            {
                switch (string.IsNullOrWhiteSpace(IconClass) ? string.Empty : IconClass)
                {
                    case "toast-success":
                    case "toast-info":
                        return "polite";
                    default:
                        return "assertive";
                }
            }
        }

        public ToastOptions Clone() => (ToastOptions)MemberwiseClone();

        private string NotNull(string s)
        {
            return (s == null) ? string.Empty : s;
        }

        #region Override methods
        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            var options = (ToastOptions)obj;
            var invariant = StringComparison.InvariantCultureIgnoreCase;
            // add null checks for added safety
            return options.Title.Equals(Title, invariant) &&
                        options.Message.Equals(Message, invariant) &&
//                        options.Type.Equals(Type, invariant) &&
                        options.ToastClass.Equals(ToastClass, invariant) &&
                        options.IconClass.Equals(IconClass, invariant) &&
                        options.CloseButtonClass.Equals(CloseButtonClass, invariant) &&
                        options.TitleClass.Equals(TitleClass, invariant) &&
                        options.MessageClass.Equals(MessageClass, invariant);
        }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
//                hash = hash * 23 + Type.GetHashCode(invariant);
                hash = hash * 23 + NotNull(Title).GetHashCode(invariant);
                hash = hash * 23 + NotNull(Message).GetHashCode(invariant);
                hash = hash * 23 + NotNull(ToastClass).GetHashCode(invariant);
                hash = hash * 23 + NotNull(IconClass).GetHashCode(invariant);
                hash = hash * 23 + NotNull(CloseButtonClass).GetHashCode(invariant);
                hash = hash * 23 + NotNull(TitleClass).GetHashCode(invariant);
                hash = hash * 23 + NotNull(MessageClass).GetHashCode(invariant);
                return hash;
            }
        }

        #endregion Override methods
    }
}
