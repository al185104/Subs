using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

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
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("FluentSystemIcons-Regular.ttf", "FluentUI");
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

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
