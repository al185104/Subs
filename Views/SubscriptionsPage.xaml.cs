using Plugin.LocalNotification;
using Subs.ViewModels;

namespace Subs.Views;

public partial class SubscriptionsPage : ContentPage
{
    public SubscriptionsPage(SubscriptionViewModel vm)
	{
		InitializeComponent();
        LocalNotificationCenter.Current.RequestNotificationPermission();
		BindingContext = vm;
    }

	protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is SubscriptionViewModel vm)
        {
            await vm.InitializeCommand.ExecuteAsync(null);
        }
    }
}