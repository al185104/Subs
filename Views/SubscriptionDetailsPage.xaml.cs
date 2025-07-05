using Subs.ViewModels;

namespace Subs.Views;

public partial class SubscriptionDetailsPage : ContentPage
{
	public SubscriptionDetailsPage(SubscriptionDetailsViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}