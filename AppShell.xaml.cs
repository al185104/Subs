using Subs.Views;

namespace Subs
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Register routes for navigation
            Routing.RegisterRoute(nameof(AddSubscriptionPage), typeof(AddSubscriptionPage));
            Routing.RegisterRoute(nameof(SubscriptionDetailsPage), typeof(SubscriptionDetailsPage));
            Routing.RegisterRoute(nameof(UpcomingRenewalPage), typeof(UpcomingRenewalPage));
        }
    }
}
