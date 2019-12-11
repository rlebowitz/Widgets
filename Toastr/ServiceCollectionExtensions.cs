using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace Toastr
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddToastService(this IServiceCollection collection, Action<ToastrConfiguration> setup)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (setup == null) throw new ArgumentNullException(nameof(setup));

            collection.Configure<ToastrConfiguration>(setup);
            return collection.AddScoped<IToastService, ToastService>();
        }
        
    }

}

