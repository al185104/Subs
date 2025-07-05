using CommunityToolkit.Mvvm.ComponentModel;
using Subs.Models;
using Subs.ViewModels.Base;

namespace Subs.ViewModels
{
    [QueryProperty(nameof(Subscription), "Subscription")]
    public partial class SubscriptionDetailsViewModel : BaseViewModel
    {
        [ObservableProperty]
        SubscriptionModel _subscription;
    }
}
