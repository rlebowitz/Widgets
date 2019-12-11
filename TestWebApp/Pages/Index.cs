using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using Toastr;

namespace TestWebApp.Pages
{
    public partial class Index
    {
        [Inject]
        public IToastService Service { get; set; }

        private readonly List<string> messages = new List<string>();
        public Index()
        {
            messages.Add("My name is Inigo Montoya. You killed my father. Prepare to die!");
            messages.Add("Are you the six fingered man?");
            messages.Add("Inconceivable!");
            messages.Add("I do not think that means what you think it means.");
            messages.Add("Have fun storming the castle!");
            messages.Add("Life isn't fair, it's just fairer than death, that's all.");
            messages.Add("Just because you're beautiful and perfect, it's made you conceited.");
            messages.Add("When I was your age, television was called books.");
            messages.Add("Do I love you? My God, if your love were a grain of sand, mine would be a universe of beaches.");
            messages.Add("We’ll never survive!");
            messages.Add("True love is the best thing in the world, except for cough drops.");
        }

        private string GetRandomMessage()
        {
            var random = new Random();
            return messages[random.Next(0, messages.Count - 1)];
        }

        private void OnAddError(MouseEventArgs args)
        {
            Service.AddErrorToast("Error", GetRandomMessage());
        }

        private void OnAddWarning(MouseEventArgs args)
        {
            Service.AddWarningToast("Warning", GetRandomMessage());
        }

        private void OnAddInfo(MouseEventArgs args)
        {
            Service.AddInfoToast("Information", GetRandomMessage());
        }

        private void OnAddSuccess(MouseEventArgs args)
        {
            Service.AddSuccessToast("Success", GetRandomMessage());
        }

        private void OnClear(MouseEventArgs args)
        {
            Service.RemoveAllToast();
        }

        private void OnCustomToast(MouseEventArgs args)
        {
            var options = Service.CreateToast();
            options.CloseButton = true;
            options.TapToDismiss = false;
            
            Service.AddToast(options, "Customization", "This is a Custom Toast");
        }

        private void Function()
        {
            System.Diagnostics.Debug.Print("Here's a test message in the output!");
        }
    }
}
