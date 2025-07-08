using CommunityToolkit.Maui;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection.Extensions; // Add this namespace
using System.Net.Http; // Ensure this namespace is included
using Subs.Data;
using Plugin.LocalNotification;

namespace Subs
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseLocalNotification()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("FluentSystemIcons-Regular.ttf", "FluentUI");
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            // Register HttpClient (for future sync)
            builder.Services.AddHttpClient();

            builder.Services.AddSingleton<Subs.ViewModels.SubscriptionViewModel>();
            builder.Services.AddTransient<Subs.ViewModels.UpcomingRenewalViewModel>();
            builder.Services.AddTransient<Subs.ViewModels.SubscriptionDetailsViewModel>();
            builder.Services.AddTransient<Subs.ViewModels.AddSubscriptionViewModel>();

            builder.Services.AddSingleton<Subs.Views.SubscriptionsPage>();
            builder.Services.AddTransient<Subs.Views.UpcomingRenewalPage>();
            builder.Services.AddTransient<Subs.Views.SubscriptionDetailsPage>();
            builder.Services.AddTransient<Subs.Views.AddSubscriptionPage>();

            return builder.Build();
        }
    }
}
