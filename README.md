# Widgets
Blazor Implementation of Toastr.js

# Register the ToastService with DI
I adopted the idea of delivering toast from a service from Chris Sainty's article "Blazor Toast Notifications Using Only C#, HTML and CSS" (https://chrissainty.com/blazor-toast-notifications-using-only-csharp-html-css/), though
that is really the only code I borrowed from his project.  I was interested in a fuller implementation of Toastr that could display multiple
toasts for a project I was working on.

Add the following line to the ConfigureServices method in your Startup.cs:
services.AddToastService(options => { Configuration.GetSection("Toastr").Bind(options); });

Add the following line to the MainLayout.razor file:
<Toaster></Toaster>

Add the following lines to your appsettings.json file:

"ToastrOptions": {
    "ContainerId": "toast-container",
    "PositionClass": "toast-top-right",
    "NewestOnTop": true,
    "PreventDuplicates": false,
    "ToastOptions": {
      "Title": "",
      "Message": "",
      "TapToDismiss": true,
      "TimeOut": 0,
      "CloseButton": false,
      "RTL": false,
      "FirstRendering": false,
      "Display": true,
      "ToastClass": "toast",
      "IconClass": "toast-info",
      "CloseButtonClass": "toast-close-button",
      "TitleClass": "toast-title",
      "MessageClass": "toast-message",
      "ShowClass": "slideDown",
      "HideClass": "fadeOut"
    }
  }

  You can find the names of the various classes that you can provide in the toastr.css file.  This file was taken directly from the Toastr.js
  project and modified slightly to incorporate some animations provided by the jQuery library in the original JavaScript library.  
  
  Inject the IToastService in each of the Razor pages that will use the component:
  
  @inject IToastService Service 
  
  or if you use partial .cs classes like me: 
  
  [Inject]
  public IToastService Service { get; set; }
  
  # How to Use the Toastr Razor Component
  The ToastService provides a series of methods used to generate error, warning, info and success toasts that look just like those created by 
  the original Toastr.js.  There's also a method called AddToast that can be used to customize toasts by applying your own CSS classes for icons,
  backgrounds, etc.  
  
  # Limitations
  There are several features I am trying to incorporate.  Currently, the fadeOut and slideUp behaviors don't work when you close a toast either 
  manually or automatically.  By the way, you can have toasts automatically disappear by setting the TimeOut appsetting to an integer value
  representing the number of milliseconds to wait until the toast (or toasts) should disappear.  
 
 
